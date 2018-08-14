using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    // Use this for initialization
    private Transform target;
    private Vector3 startOffset;
    private Vector3 moveVector;
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        startOffset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = target.position + startOffset;

        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y,0.3f,1);

        transform.position = moveVector;
	}
}
