using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour {

    public static GlobalSettings Instance;

    [Header("Roads")]
    public GameObject RoadParent;
    public GameObject RoadPrefab;
    public int roadCount;
    public int roadMaxCount = 3;
    public float speed;
    public float roadSize = 10;

    [Header("Cars")]
    public GameObject CarParent;
    public GameObject CarPrefab;
    public int maxCars;
    public List<string> CarNames;

    void Start ()
    {
        Instance = this;
	}

    public void SpawnCars(Transform Parent)
    {
        if (CarParent.transform.childCount >= maxCars)
            return;

        GameObject obj = Instantiate<GameObject>(CarPrefab);
        obj.name = CarNames[Random.Range(0, CarNames.Count)];

        obj.transform.SetParent(CarParent.transform);
        float randomX = Random.Range(-4, 4);
        obj.transform.localPosition = new Vector3(randomX, obj.transform.localPosition.y, roadSize * (roadCount - 1));

        float randomSpeed = Random.Range(1, speed);
        obj.GetComponent<CarMovement>().carSpeed = randomSpeed;
    }

    public void SpawnRoad()
    {
        roadCount = RoadParent.transform.childCount;

        GameObject obj = Instantiate<GameObject>(RoadPrefab);

        obj.transform.SetParent(RoadParent.transform);
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, roadSize * (roadCount - 1));

        int random = Random.Range(0, 2);
        for (int i = 0; i < random; i++)
        {
            SpawnCars(obj.transform);
        }
    }

}
