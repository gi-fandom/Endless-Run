using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speedX;
    float moveX;

	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localPosition.x >= -4)
                moveX -= speedX * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.localPosition.x <= 4)
                moveX += speedX * Time.deltaTime;
        }

        transform.localPosition = new Vector3(moveX, transform.localPosition.y, transform.localPosition.z);
    }
}
