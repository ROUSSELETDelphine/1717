using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWeapon : MonoBehaviour {

    public GameObject[] weapons;
    public bool showWeapons;

	// Use this for initialization
	void Start () {
        showWeapons = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (showWeapons == false)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
        }

        if (showWeapons == true)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           showWeapons = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            showWeapons = true;
        }
	}
}
