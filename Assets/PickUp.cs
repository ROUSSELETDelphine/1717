using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    public GameObject player;
    public GameObject pickUpText;
    private MyInventory inventory;
    public string type;

	// Use this for initialization
	void Start () {
        inventory = player.GetComponent<MyInventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Team2")
        {
            if (pickUpText != null)
                pickUpText.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Team2")
        { 
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUpText.SetActive(false);
                Destroy(gameObject);
                // Incrémenter compteur sur le UI
                if (type.Equals("syringe"))
                {
                    inventory.addSynringe();
                } else if (type.Equals("pills"))
                {
                    inventory.addPills();
                } else if (type.Equals("card"))
                {
                    inventory.addCard();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        print("Exit");
        if (other.gameObject.tag == "Team2")
        {
            if (pickUpText != null)
                pickUpText.SetActive(false);
        }
    }

}
