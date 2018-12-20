using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldatLeftShoulderMovement : MonoBehaviour {

    public bool isMovingForward;
    public bool isMovingBackward;
    public bool isMovingLeft;
    public bool isMovingRight;
    public bool isAiming;
    public bool isHurt;
    public bool isDying;

    private Quaternion lastRotation;

    // Use this for initialization
    void Start () {
        isMovingForward = false;
        isMovingBackward = false;
        isMovingLeft = false;
        isMovingRight = false;
        isAiming = false;
        isHurt = false;
        isDying = false;

        lastRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        /*
        if (!isMovingForward && !isMovingBackward && !isMovingLeft && !isMovingRight && !isAiming && !isHurt && !isDying)
        {
            transform.rotation.Set(lastRotation.x, lastRotation.y, lastRotation.z, 1);
        }
        else
        {
            lastRotation = transform.rotation;
        }
        */

        if (isMovingForward == true) transform.Rotate(0, -1, 5);
        else transform.Rotate(0, 1, -5);

        if (isMovingBackward == true) transform.Rotate(0, -1, 5);
        else transform.Rotate(0, 1, -5);

        if (isMovingLeft == true) transform.Rotate(0, 5, 0);
        else transform.Rotate(0, -5, 0);

        if (isMovingRight == true) transform.Rotate(0, 5, 0);
        else transform.Rotate(0, -5, 0);

        if (isAiming == true) transform.Rotate(0, 5, 0);
        else transform.Rotate(0, -5, 0);

        if (isHurt == true) transform.Rotate(0, -5, 0);
        else transform.Rotate(0, 5, 0);

        if (isDying == true) transform.Rotate(0, 5, 0);
        else transform.Rotate(0, -5, 0);
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

        if (boolean == "isHurt")
        {
            isHurt = true;
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

        if (boolean == "isBackForward")
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

        if (boolean == "isHurt")
        {
            isHurt = false;
        }

        if (boolean == "isDying")
        {
            isDying = false;
        }
    }
}
