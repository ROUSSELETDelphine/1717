using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldatRightForeArmMovement : MonoBehaviour {

    public bool isMovingForward;
    public bool isMovingBackward;

	// Use this for initialization
	void Start () {
        isMovingForward = false;
        isMovingBackward = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // LastUpdate is called after Update and animations so you can overwrite them
    void LateUpdate()
    {
        if (isMovingForward == true) transform.Rotate(0, 0, -10);
        if (isMovingBackward == true) transform.Rotate(0, 0, -10);
    }

    void SetBooleanTrue(string boolean)
    {
        if (boolean == "isMovingForward")
        {
            isMovingForward = true;
        }

        if (boolean == "isMovingBackward")
        {
            isMovingBackward = true;
        }

    }

    void SetBooleanFalse(string boolean)
    {
        if (boolean == "isMovingForward")
        {
            isMovingForward = false;
        }

        if (boolean == "isMovingBackward")
        {
            isMovingBackward = false;
        }
    }
}
