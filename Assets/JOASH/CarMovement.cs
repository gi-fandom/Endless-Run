using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public float carSpeed;
    float moveZ;

    void Start()
    {
        moveZ = transform.localPosition.z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * carSpeed);
            Debug.Log(gameObject.name + " Collided with Player");
        }
    }
 
    void Update()
    {
        moveZ -= (GlobalSettings.Instance.speed / 100f) - (carSpeed / 100f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, moveZ);

        if (transform.localPosition.z <= -GlobalSettings.Instance.roadSize)
        {
            Destroy(gameObject);
        }
    }
}
