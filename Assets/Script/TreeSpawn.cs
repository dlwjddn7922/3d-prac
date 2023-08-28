using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public List<Transform> EnvirmentObjList = new List<Transform>();
    public List<GameObject> tree = new List<GameObject>();
    public float StartMinVal = -0.712f;
    public float StartMaxVal = 0.697f;

    public int SpawnCreateRandom = 50;
    // Start is called before the first frame update

    void GeneratorEnvirment()
    {
        int randomindex = 0;
        int randomval = 0;
        GameObject tempClone = null;
        Vector3 offsetPos = Vector3.zero;
        for (float i = StartMinVal; i < StartMaxVal; i++)
        {
            randomval = Random.Range(0, 100);
            if(randomval < SpawnCreateRandom)
            {
                randomindex = Random.Range(0, EnvirmentObjList.Count);
                tempClone = GameObject.Instantiate(tree[randomindex].gameObject);               
                offsetPos.Set(i, 0f, 0f);
               
                tempClone.transform.SetParent(this.transform);
                tempClone.transform.localPosition = offsetPos;
            }

        }
    }
    void Start()
    {
        GeneratorEnvirment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
