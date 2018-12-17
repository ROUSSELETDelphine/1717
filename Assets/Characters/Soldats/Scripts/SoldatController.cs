using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldatController : MonoBehaviour {

    public GameObject leftShoulder;
    public GameObject rightForeArm;
    public GameObject weapon;
    static Animator anim;

    public bool isMovingForward;
    public bool isMovingBackward;
    public bool isMovingLeft;
    public bool isMovingRight;
    public bool isAiming;
    public bool isDying;
    public bool isHurt;
    public bool isHeadShot; //unused

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isMovingForward", false);
        anim.SetBool("isMovingBackward", false);
        anim.SetBool("isMovingLeft", false);
        anim.SetBool("isMovingRight", false);
        anim.SetBool("isAiming", false);
        anim.SetBool("isDying", false);
        anim.SetBool("isHurt", false);
        anim.SetBool("isHeadShot", false);
    }
	
	// Update is called once per frame
	void Update () {
        rightForeArm.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
        rightForeArm.SendMessageUpwards("SetBooleanFalse", "isMovingBackward", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingBackward", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingLeft", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingRight", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isAiming", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isHurt", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isDying", SendMessageOptions.DontRequireReceiver);

        print("movingForward");
        print(isMovingForward);
        if (isMovingForward == true)
        {
            print("JE BOUGE MA RACE");
            anim.SetBool("isMovingForward", true);
            rightForeArm.SendMessageUpwards("SetBooleanTrue", "isMovingForward", SendMessageOptions.DontRequireReceiver);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isMovingForward", SendMessageOptions.DontRequireReceiver);
        }
        if (isMovingForward == false)
        {
            anim.SetBool("isMovingForward", false);
        }
        /*
        if (isMovingBackward == true)
        {
            anim.SetBool("isMovingBackward", true);
            rightForeArm.SendMessageUpwards("SetBooleanTrue", "isMovingBackward", SendMessageOptions.DontRequireReceiver);
        }

        if (isMovingLeft == true)
        {
            anim.SetBool("isMovingLeft", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isMovingLeft", SendMessageOptions.DontRequireReceiver);
        }

        if (isMovingRight == true)
        {
            anim.SetBool("isMovingRight", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isMovingRight", SendMessageOptions.DontRequireReceiver);
        }

        if (isAiming == true)
        {
            anim.SetBool("isAiming", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);
        }

        if (isDying == true)
        {
            anim.SetBool("isDying", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isDying", SendMessageOptions.DontRequireReceiver);
        }

        if (isHurt == true)
        {
            anim.SetBool("isHurt", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isDying", SendMessageOptions.DontRequireReceiver);
        }
        */
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

        if (boolean == "isHeadShot")
        {
            isHeadShot = true;
        }

        if (boolean == "isHurt") isHurt = true;

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

        if (boolean == "isHeadShot") isHeadShot = false;
        if (boolean == "isHurt") isHurt = false;

    }
}
