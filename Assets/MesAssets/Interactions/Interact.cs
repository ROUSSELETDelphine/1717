using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public AudioSource source;
    public GameObject Pivot, Porte;
    public int Angle = 130;
    private int CurAngle;
    public bool Ouverture = false;
    private bool keyE = false;
    public GameObject interaction_text;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2") && !Ouverture)
        {
            if (interaction_text != null)
            {
                interaction_text.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                source.PlayOneShot(source.clip);
                keyE = true;
                interaction_text.SetActive(false);
            }
        }

        if (keyE)
        {
            if (CurAngle < Angle)
            {
                CurAngle += 1;
                Porte.transform.RotateAround(Pivot.transform.position, -Vector3.up, CurAngle * Time.deltaTime);
            } else
            {
                Ouverture = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Team2"))
        {
            if (interaction_text != null)
            {
                interaction_text.SetActive(false);
            }
        }
    }
}