using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLeftShoulderMovement : MonoBehaviour {

    public bool isMovingForward;
    public bool isMovingBackward;
    public bool isMovingLeft;
    public bool isMovingRight;
    public bool isAiming;
    public bool isDying;

    // Use this for initialization
    void Start () {
        isMovingForward = false;
        isMovingBackward = false;
        isMovingLeft = false;
        isMovingRight = false;
        isAiming = false;
        isDying = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // LateUpdate is called after Update and animations so you can overwrite them
    void LateUpdate()
    {
        if (isMovingForward == true) transform.Rotate(0, -5, -30);
        if (isMovingBackward == true) transform.Rotate(0, -5, -30);
        if (isMovingLeft == true) transform.Rotate(0, -5, -15);
        if (isMovingRight == true) transform.Rotate(0, -5, -15);
        if (isAiming == true) transform.Rotate(0, 0, -20);
        if (isDying == true) transform.Rotate(0, -5, -30);
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

        if (boolean == "isMovingLeft")
        {
            isMovingLeft = true;
        }

        if (boolean == "isMovingRight")
        {
            isMovingRight = true;
        }

        if (boolean == "isAiming")
        {
            isAiming = true;
        }

        if (boolean == "isDying")
        {
            isDying = true;
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

        if (boolean == "isMovingLeft")
        {
            isMovingLeft = false;
        }

        if (boolean == "isMovingRight")
        {
            isMovingRight = false;
        }

        if (boolean == "isAiming")
        {
            isAiming = false;
        }

        if (boolean == "isDying")
        {
            isDying = false;
        }

    }
}
