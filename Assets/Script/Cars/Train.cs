using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    float MoveSpeed = 30f;
    float RangeDestory = 0.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = MoveSpeed * Time.deltaTime;
        this.transform.Translate(0f, 0f, moveX);

        if (this.transform.localPosition.z >= RangeDestory)
        {
            Destroy(this.gameObject);
        }
    }
}
