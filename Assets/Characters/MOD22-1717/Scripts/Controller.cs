using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public bool weaponEquiped = false;

    static Animator anim;

    // Keyboard mouvements
    public float speed = 10.0F;
    public float rotationSpeed = 70.0F;
    public bool stopWalking;
    public bool isTurningRight;
    public bool isTurningLeft;
    public bool aimPistol;

    // Mouse movements
    public float speedH = 2.0f;
    private float yawX = 0.0f;
    

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        isTurningRight = false;
        isTurningLeft = false;
    }

    private void FixedUpdate()
    {
        stopWalking = Physics.Raycast(transform.position, Vector3.forward, 0.67F);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation with mouse
        yawX += speedH * Input.GetAxis("Mouse X");
        if (aimPistol == true)
        {
            transform.eulerAngles = new Vector3(0, yawX + 22);
        }
        // ici
        else
        {
            transform.eulerAngles = new Vector3(0, yawX);
        }
        

        // Moving movements
        float translation = Input.GetAxis("Vertical") * 2;
        float translationLR = Input.GetAxis("Horizontal") * 2;

        translation *= Time.deltaTime*speed;
        translationLR *= Time.deltaTime*speed;
        transform.Translate(0, 0, translation);
        transform.Translate(translationLR, 0, 0);
        


        if (translationLR > 0)
        {
            isTurningRight = true;
            anim.SetBool("isTurningRight", true);
            anim.SetBool("isTurningLeft", false);
        }
        else
        {
            if (translationLR < 0)
            {
                isTurningLeft = true;
                anim.SetBool("isTurningLeft", true);
                anim.SetBool("isTurningRight", false);
            }
            else
            {
                anim.SetBool("isTurningLeft", false);
                anim.SetBool("isTurningRight", false);
            }
        }
       
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponEquiped)
        {
            aimPistol = true;
            anim.SetBool("isAimingPistol", true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            aimPistol = false;
            anim.SetBool("isAimingPistol", false);
        }

        if ((translationLR != 0 || translation != 0) && stopWalking != true)
        {
            if (translation > 0)
            {
                anim.SetBool("isMovingForward", true);
                anim.SetBool("isMovingBackward", false);
            }
            else
            {
                anim.SetBool("isMovingBackward", true);
                anim.SetBool("isMovingForward", false);
            }
            
        }
        else
        {
            anim.SetBool("isMovingForward", false);
            anim.SetBool("isMovingBackward", false);
        }
    }

    void LateUpdate()
    {
        
    }


}
