using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Car CloneTarget;
    [SerializeField] Transform GenerationPos;
    public int GenerationPersent = 30;

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
        if(currSec >= NextSecToClone)
        {
            int randomVal = Random.Range(0, 100);
            if(randomVal <= GenerationPersent)
            {
                CloneCar();
            }
            currSec = 0f;
            //NextSecToClone = currSec + CloneDelaySec;
        }
        if (UI.Instance.Score >= 40)
        {
            GenerationPersent = 40;
        }
        else if (UI.Instance.Score >= 70)
        {
            GenerationPersent = 50;
        }
        else if (UI.Instance.Score >= 100)
        {
            GenerationPersent = 60;
        }
    }
    void CloneCar()
    {
        Transform clonePos = GenerationPos;
        Vector3 offsetPos = clonePos.position;
        offsetPos.y = 1f;

        GameObject cloneobj = GameObject.Instantiate(CloneTarget.gameObject, offsetPos, GenerationPos.rotation, this.transform);
        cloneobj.SetActive(true);
    }
}
