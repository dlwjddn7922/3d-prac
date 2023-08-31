using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float MoveSpeed = 6f;
    float RangeDestory = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = MoveSpeed * Time.deltaTime;
        this.transform.Translate(0f, 0f, moveX);

        if(this.transform.localPosition.z >= RangeDestory)
        {
            Destroy(this.gameObject);
        }
        if(UI.Instance.Score >= 40)
        {
            MoveSpeed = 8f;
        }
        else if(UI.Instance.Score >= 70)
        {
            MoveSpeed = 10f;
        }
        else if(UI.Instance.Score >= 100)
        {
            MoveSpeed = 12f;
        }
    }
}
