using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum E_RoadType
    {
        Road = 0,
        BusRoad,
        Water,
        TrainRoad,
        land,
        Max
    }
    public enum E_LastRoadType
    {
        Road = 0,
        BusRoad,
        Water,
        TrainRoad,
        land,
        Max
    }
    //[SerializeField] private GameObject[] RoadObjArray;
    [SerializeField] private Road road;
    [SerializeField] private BusRoad busroad;
    [SerializeField] private Water water;
    [SerializeField] private TrainRoad trainroad;
    [SerializeField] private GameObject land1;
    [SerializeField] private GameObject plane;
    protected List<Transform> MapList = new List<Transform>();
    protected Dictionary<int, Transform> MapDic = new Dictionary<int, Transform>();
    protected E_LastRoadType lastRoadType = E_LastRoadType.Max;
    protected int lastPos = 0;
    public int minPos = -20;
    public int maxPos = 20;
    public int FrontOffsetPosz = 10;
    public int BackOffsetPosz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateForwardBackMove(int p_posz)
    {
        if (MapList.Count <= 0)
        {
            lastRoadType = E_LastRoadType.TrainRoad;
            int i = 0;
            for (i = minPos; i < maxPos; i++)
            {
                int setVal = 0;
                if (i < 0)
                {
                    GenerateLand(i);
                }
                else
                {
                    if (lastRoadType == E_LastRoadType.TrainRoad)
                    {
                        int randomval = Random.Range(0, 3);
                        if (randomval == 0)
                        {
                            setVal = RandomWater(i);

                        }
                        else if (randomval == 1)
                        {
                            setVal = RandomBusRoad(i);
                        }
                        else if (randomval == 2)
                        {
                            setVal = RandomLand(i);
                        }
                        else if (randomval == 3)
                        {
                            setVal = RandomTrainRoad(i);
                        }
                        lastRoadType = E_LastRoadType.Road;
                    }
                    else
                    {
                        setVal = RandomRoad(i);
                        lastRoadType = E_LastRoadType.TrainRoad;
                    }
                    i += setVal - 1;
                }
            }
            lastPos = i;
        }
        if(lastPos < p_posz + FrontOffsetPosz)
        {           
            int setVal = 0;
            if (lastRoadType == E_LastRoadType.TrainRoad)
            {
                int randomval = Random.Range(0, 4);
                if (randomval == 0)
                {
                    setVal = RandomWater(lastPos);

                }
                else if (randomval == 1)
                {
                    setVal = RandomTrainRoad(lastPos);
                }
                else if (randomval == 2)
                {
                    setVal = RandomBusRoad(lastPos);
                    //setVal = RandomLand(lastPos);
                }
                else if (randomval == 3)
                {
                    setVal = RandomLand(lastPos);

                    //setVal = RandomBusRoad(lastPos);
                }
                lastRoadType = E_LastRoadType.Road;
            }
            else
            {
                setVal = RandomRoad(lastPos);
                lastRoadType = E_LastRoadType.TrainRoad;
            }
            lastPos += setVal;
        }
    }
    public int RandomLand(int p_pos)
    {
        int randomCount = Random.Range(1, 4);
        for (int i = 0; i < randomCount; i++)
        {
            GenerateLand(p_pos + i);
        }
        return randomCount;
    }
    public void GenerateLand(int p_pos)
    {
        GameObject cloneObj = GameObject.Instantiate(land1.gameObject);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos * 1.8f;
        p_pos = p_pos * 2;
        //cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;
        cloneObj.name = "Land" + p_pos.ToString();
        cloneObj.gameObject.SetActive(true);
        MapList.Add(cloneObj.transform);
        MapDic.Add(p_pos, cloneObj.transform);
    }
    public int RandomRoad(int p_pos)
    {
        int randomCount = Random.Range(1, 4);
        for (int i = 0; i < randomCount; i++)
        {
            GenerateRoad(p_pos + i);
        }
        return randomCount;
    }
    public void GenerateRoad(int p_pos)
    {
        GameObject cloneObj = GameObject.Instantiate(road.gameObject);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos * 1.8f;
        p_pos = p_pos * 2;
        //cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;
        cloneObj.name = "Road" + p_pos.ToString();
        cloneObj.gameObject.SetActive(true);
        MapList.Add(cloneObj.transform);
        MapDic.Add(p_pos, cloneObj.transform);
    }
    public int RandomBusRoad(int p_pos)
    {
        int randomCount = Random.Range(1, 4);
        for (int i = 0; i < randomCount; i++)
        {
            GenerateBusRoad(p_pos + i);
        }
        return randomCount;
    }
    public void GenerateBusRoad(int p_pos)
    {
        GameObject cloneObj = GameObject.Instantiate(busroad.gameObject);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos * 1.8f;
        p_pos = p_pos * 2;
        //cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;
        cloneObj.name = "BusRoad" + p_pos.ToString();
        cloneObj.gameObject.SetActive(true);
        MapList.Add(cloneObj.transform);
        MapDic.Add(p_pos, cloneObj.transform);
    }
    public int RandomTrainRoad(int p_pos)
    {
        int randomCount = Random.Range(1, 3);
        for (int i = 0; i < randomCount; i++)
        {
            GenerateTrainRoad(p_pos + i);
        }
        return randomCount;
    }
    public void GenerateTrainRoad(int p_pos)
    {
        GameObject cloneObj = GameObject.Instantiate(trainroad.gameObject);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos * 1.8f;
        p_pos = p_pos * 2;
        //cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;
        cloneObj.name = "TrainRoad" + p_pos.ToString();
        cloneObj.gameObject.SetActive(true);
        MapList.Add(cloneObj.transform);
        MapDic.Add(p_pos, cloneObj.transform);
    }
    public int RandomWater(int p_pos)
    {
        int randomCount = Random.Range(1, 1);
        for (int i = 0; i < randomCount; i++)
        {
            GenerateWater(p_pos + i);
        }
        return randomCount;
    }
    public void GenerateWater(int p_pos)
    {
        GameObject cloneObj = GameObject.Instantiate(water.gameObject);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos *1.8f;
        p_pos = p_pos * 2;
       //cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;
        cloneObj.name = "Water" + p_pos.ToString();
        cloneObj.gameObject.SetActive(true);
        MapList.Add(cloneObj.transform);
        MapDic.Add(p_pos, cloneObj.transform);
    }
    /*public void Generateland(int p_posz)
    {

    }*/
/*    void CloneRoad(float p_pos)
    {
        int randomIndex = Random.Range(0, RoadObjArray.Length);
        GameObject cloneObj = GameObject.Instantiate(RoadObjArray[randomIndex]);
        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = p_pos;
        cloneObj.transform.SetParent(parentTrans);
        cloneObj.transform.position = offsetPos;


    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
