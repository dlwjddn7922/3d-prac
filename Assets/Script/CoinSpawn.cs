using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform[] coinroads;
    [SerializeField] private Transform parent;
    public int SpawnCreateRandom = 30;



    // Start is called before the first frame update
    void Start()
    {
        CoinRandomSpawn();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CoinRandomSpawn()
    {
        for (int i = 0; i < coinroads.Length; i++)
        {
            int randomval = Random.Range(0, 100);
            Vector3 createPos = coinroads[i].transform.position;
            if(randomval <= SpawnCreateRandom)
            {
                createPos.y += 0.5f; 
                GameObject obj = Instantiate(coin, createPos,Quaternion.identity);
                obj.transform.SetParent(parent);
                
                //coin.transform.position.y = 
            }
        }
    }
}
