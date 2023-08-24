using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRoad : MonoBehaviour
{
    [SerializeField] private Train CloneTarget;
    [SerializeField] Transform GenerationPos;
    public int GenerationPersent = 100;

    public float CloneDelaySec = 10f;

    protected float NextSecToClone = 10f;
    float currSec = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currSec += Time.deltaTime;
        if (currSec >= NextSecToClone)
        {
            int randomVal = Random.Range(0, 100);
            if (randomVal <= GenerationPersent)
            {
                CloneCar();
            }
            currSec = 0f;
            //NextSecToClone = currSec + CloneDelaySec;
        }
    }
    void CloneCar()
    {
        Transform clonePos = GenerationPos;
        Vector3 offsetPos = clonePos.position;
        offsetPos.y = 0.3f;

        GameObject cloneobj = GameObject.Instantiate(CloneTarget.gameObject, offsetPos, GenerationPos.rotation, this.transform);
        cloneobj.SetActive(true);
    }
}
