using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigicodeInteract : MonoBehaviour {

    private bool open, zoomIn, isValid;
    public GameObject player, digicodeCam, enterCodeText, quitText;
    public CodeClass codeClass;

	// Use this for initialization
	void Start () {
        open = false;
        zoomIn = false;
        isValid = codeClass.isValid;
    }

	
	// Update is called once per frame
	void Update () {

        if (!isValid && codeClass.isValid)
        {
            isValid = codeClass.isValid;
            enterCodeText.SetActive(false);
            quitText.SetActive(false);
            digicodeCam.SetActive(false);
            player.SetActive(true);
        }

        if (!isValid && Input.GetKeyDown(KeyCode.R) && !open && zoomIn)
        {
            quitText.SetActive(false);
            enterCodeText.SetActive(true);
            digicodeCam.SetActive(false);
            player.SetActive(true);
            zoomIn = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isValid && other.gameObject.tag.Equals("Team2") && !open)
        {
            if (enterCodeText != null)
            {
                enterCodeText.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isValid && other.gameObject.tag.Equals("Team2"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !open && !zoomIn)
            {
                enterCodeText.SetActive(false);
                quitText.SetActive(true);
                player.SetActive(false);
                digicodeCam.SetActive(true);
                zoomIn = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!isValid && other.gameObject.tag.Equals("Team2"))
        {
            if (enterCodeText != null)
            {
                enterCodeText.SetActive(false);
                quitText.SetActive(false);
            }
        }
    }
}
