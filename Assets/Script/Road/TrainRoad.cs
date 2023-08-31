using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRoad : MonoBehaviour
{
    [SerializeField] private Train CloneTarget;
    [SerializeField] Transform GenerationPos;
    [SerializeField] Light trainLight;
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
            CloneCar();
            currSec = 0f;
        }
        if (UI.Instance.Score >= 0)
        {
            if (currSec >= 8f)
            {
                trainLight.color = Color.red;
            }
            else
            {
                trainLight.color = Color.green;
            }
            NextSecToClone = 10;
        }
        else if (UI.Instance.Score >= 40)
        {
            if (currSec >= 6f)
            {
                trainLight.color = Color.red;
            }
            else
            {
                trainLight.color = Color.green;
            }
            NextSecToClone = 8;
        }
        else if (UI.Instance.Score >= 70)
        {
            if (currSec >= 4f)
            {
                trainLight.color = Color.red;
            }
            else
            {
                trainLight.color = Color.green;
            }
            NextSecToClone = 6;
        }
        else if (UI.Instance.Score >= 100)
        {
            if (currSec >= 3f)
            {
                trainLight.color = Color.red;
            }
            else
            {
                trainLight.color = Color.green;
            }
            NextSecToClone = 5;
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
}
