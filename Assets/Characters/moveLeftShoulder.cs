using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftShoulder : MonoBehaviour {

    public bool aimPistol;

    // Mouse movements
    public float speedH = 3.0f;
    private float yawY = 0.0f;
    public int maxYaw = 8;

    // Use this for initialization
    void Start () {
        aimPistol = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            aimPistol = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            aimPistol = false;
        }
    }


    // LateUpdate is called after Update and the animation so it allows us to overwrite the position of the arm
    void LateUpdate()
    {
        if (aimPistol == true)
        {
            // Rotation with mouse
            yawY -= speedH * Input.GetAxis("Mouse Y");
            //print("yawY");
            //print(yawY);
            
            //The arm rotates according to the mouse inputs
            if (yawY > -15 && yawY < 15)
            {
                transform.Rotate(0, -yawY, yawY / 4);
            }
            else
            {
                // Unable maximum range for shooting on Y axis
                if (yawY < -15)
                {
                    transform.Rotate(0, maxYaw, -maxYaw / 4);
                }
                if (yawY > 15)
                {
                    transform.Rotate(0, -maxYaw, maxYaw / 4);
                }
            }

            transform.Rotate(0, 0, -14);
            
        }
    }
}
