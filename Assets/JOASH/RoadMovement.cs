using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour {

    float moveZ;

    void Start()
    {
        moveZ = transform.localPosition.z;
    }

    void Update()
    {
        moveZ -= GlobalSettings.Instance.speed / 100f;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, moveZ);

        if (transform.localPosition.z <= -GlobalSettings.Instance.roadSize)
        {
            GlobalSettings.Instance.SpawnRoad();
            Destroy(gameObject);
        }
    }
}
