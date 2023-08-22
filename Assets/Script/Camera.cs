using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    public float smoothing = 5f;

    Vector3 offsetVal;
    // Start is called before the first frame update
    void Start()
    {
        offsetVal = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 cameraPos = target.position + offsetVal;
            transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
        }

    }
}
