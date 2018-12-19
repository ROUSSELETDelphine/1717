using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponController : MonoBehaviour {

    public bool isAiming;

	// Use this for initialization
	void Start () {
        isAiming = false;
    }
	
	// Update is called once per frame
	void Update () {
        

    }
    
    // Translate and rotate the weapon according to the animation
    void LateUpdate()
    {
        if (isAiming == true)
        {
            //transform.eulerAngles = new Vector3(30, -30, 0);
            // TD: C EST DE LA MERDE
            //transform.position = new Vector3(0f, 0f, 0f);
            //transform.position.Set(0f, -100f, 10f);
        }
    }

    void SetBooleanTrue(string boolean)
    {
        if (boolean == "isAiming")
        {
            isAiming = true;
        }
  
    }

    void SetBooleanFalse(string boolean)
    {

        if (boolean == "isAiming")
        {
            isAiming = false;
        }
    }

}
