using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("isMovingForward", false);
        anim.SetBool("isMovingBackward", false);
        anim.SetBool("isMovingLeft", false);
        anim.SetBool("isMovingRight", false);
        anim.SetBool("isAiming", false);
        anim.SetBool("isDying", false);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingBackward", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingLeft", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isMovingRight", SendMessageOptions.DontRequireReceiver);
        rightForeArm.SendMessageUpwards("SetBooleanFalse", "isAiming", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isAiming", SendMessageOptions.DontRequireReceiver);
        leftShoulder.SendMessageUpwards("SetBooleanFalse", "isDying", SendMessageOptions.DontRequireReceiver);

        // VALEUR POUR TEST
        isDying = true;

        if (isMovingForward == true)
        {
            anim.SetBool("isMovingForward", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isMovingForward", SendMessageOptions.DontRequireReceiver);
        }

        if(isMovingBackward == true)
        {
            anim.SetBool("isMovingBackward", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isMovingBackward", SendMessageOptions.DontRequireReceiver);
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
            rightForeArm.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);
        }

        if (isDying == true)
        {
            anim.SetBool("isDying", true);
            leftShoulder.SendMessageUpwards("SetBooleanTrue", "isDying", SendMessageOptions.DontRequireReceiver);
        }
    }
}
