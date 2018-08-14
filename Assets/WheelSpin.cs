using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour {

    public GameObject mainBody;
    Movement movmentScript;
	// Use this for initialization
	void Start () {
        movmentScript = mainBody.GetComponent<Movement>();
        mainBody = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {


        transform.Rotate(0, 0, (movmentScript.speed));
        //
	}
}
