using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
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
        if (other.gameObject.tag.Equals("Team2"))
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
                //Lancement de l'animation
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