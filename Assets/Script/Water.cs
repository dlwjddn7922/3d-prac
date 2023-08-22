using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Raft CloneTarget;
    [SerializeField] Transform GenerationPos;
    public int GenerationPersent = 50;

    public float CloneDelaySec = 2f;

    protected float NextSecToClone = 2f;
    float currSec = 2f;
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
        offsetPos.y = 0.5f;

        GameObject cloneobj = GameObject.Instantiate(CloneTarget.gameObject, offsetPos, GenerationPos.rotation, this.transform);
        Vector3 position = cloneobj.gameObject.transform.position;
        position.y = 0.005f;
        cloneobj.SetActive(true);
    }
}
