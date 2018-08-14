using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> roadPrefabs;
    public List<GameObject> instantiatedPrefabs = new List<GameObject>();
    public Transform playerTransform;
    public float spawnZ;
    public float roadLength = 48.684582f;
    public int maxNoOfRoad = 5;
    public float safeZone = 60.0f;
	void Start () {


        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPrefab(0);

        for (int i = 1; i < maxNoOfRoad; i++) {
            SpawnPrefab(Random.Range(0, roadPrefabs.Count));

        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (playerTransform.position.z -safeZone > (spawnZ - maxNoOfRoad * roadLength)) {
            SpawnPrefab(Random.Range(0, roadPrefabs.Count - 1));

            if(instantiatedPrefabs.Count>maxNoOfRoad   )
            DeleteRoad();
        }
		

	}

    void SpawnPrefab(int index = -1) {

        GameObject obj = Instantiate<GameObject>(roadPrefabs[index]);
        instantiatedPrefabs.Add(obj);


        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;

    }
    void DeleteRoad() {

        GameObject.Destroy(instantiatedPrefabs[0]);
        instantiatedPrefabs.RemoveAt(0);
        
    }
}
