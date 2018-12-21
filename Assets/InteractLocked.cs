using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLocked : MonoBehaviour
{
    public AudioSource source;
    public GameObject Pivot, Porte;
    public GameObject player;
    public float amountEuphoria;
    private MentalHealthManager health;
    private MyInventory inventory;
    public int Angle = 130;
    private int CurAngle;
    private bool Ouverture = false;
    private bool keyE = false;
    public GameObject open_text, locked_text;

    void Start()
    {
        inventory = player.GetComponent<MyInventory>();
        health = player.GetComponent<MentalHealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2") && !Ouverture)
        {
            if (open_text != null)
            {
                open_text.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2"))
        {
            if (Input.GetKeyDown(KeyCode.E) && inventory.haveCard)
            {
                source.PlayOneShot(source.clip);
                keyE = true;
                open_text.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && !inventory.haveCard)
            {
                open_text.SetActive(false);
                locked_text.SetActive(true);
            }
        }

        if (keyE)
        {
            if (CurAngle < Angle)
            {
                CurAngle += 1;
                Porte.transform.RotateAround(Pivot.transform.position, -Vector3.up, CurAngle * Time.deltaTime);
            }
            else if (!Ouverture) 
            {
                Ouverture = true;
                health.changeMentalState(amountEuphoria);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2"))
        {
            if (open_text != null)
            {
                open_text.SetActive(false);
                locked_text.SetActive(false);
            }
        }
    }
}