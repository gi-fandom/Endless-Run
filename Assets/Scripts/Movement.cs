using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {

    // Use this for initialization
    CharacterController playerController;
    public float speed = 1f;
    Vector3 movementVector;
    
	void Start () {
        playerController = GetComponent<CharacterController>();
	}
	
	
	void Update () {
        movementVector = Vector3.zero;

        if (playerController.isGrounded)
        {
            movementVector.y = -0.5f;

        }
        else {

            movementVector.y = -9.8f;
        }


        movementVector.x = Input.GetAxisRaw("Horizontal") * speed;
        movementVector.z = speed;


        playerController.Move(movementVector * Time.deltaTime);	
	}
}
