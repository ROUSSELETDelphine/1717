using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRightForeArm : MonoBehaviour {

    public bool isAiming;

	// Use this for initialization
	void Start () {
        isAiming = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if (isAiming == true)
        {
            transform.Rotate(0, 0, -20);
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
