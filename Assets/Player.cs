using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Player : MonoBehaviour {

    public GameObject mainCam;
    public List<CarProperty> playerCar;
    public CarType currentCarType;

    void Start () {
		
	}
	
	void Update () {
        CheckCarType();
	}

    void CheckCarType() {
        var current = playerCar.Where(x => x.type == currentCarType).FirstOrDefault();

        if (current!=null)
        current.gameObject.SetActive(true);

        playerCar.Where(x => x.type != currentCarType && x.gameObject.activeSelf).FirstOrDefault(i => {
            i.gameObject.SetActive(false); return false;
        });


        mainCam.transform.localPosition = current.cameraAngle;
    }
}
public enum CarType
{

    //Carton,
    //Tricycle,
    Car,
    Truck



}

[System.Serializable]
public class CarProperty {

    public string name;
    public CarType type;
    public GameObject gameObject;
    public Vector3 cameraAngle;

    public int GetSize() {

        return (int)type;
    }

}