using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MyInventory : MonoBehaviour
{
    private MentalHealthManager health;
    public GameObject syringesObject;
    public GameObject pillsObject;
    private TextMeshProUGUI syringesUI;
    private TextMeshProUGUI pillsUI;
    public int syringes;
    public int pills;
    public bool haveCard;

    void Start()
    {
        health = gameObject.GetComponent<MentalHealthManager>();
        syringesUI = syringesObject.GetComponent<TextMeshProUGUI>();
        pillsUI = pillsObject.GetComponent<TextMeshProUGUI>();
        haveCard = false;
        syringesUI.text = syringes.ToString();
        pillsUI.text = pills.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && pills > 0)
        {
            // Use Pills
            health.changeMentalState(-20);
            pills--;
            pillsUI.text = pills.ToString();
        }
        if (Input.GetKeyDown(KeyCode.V) && syringes > 0)
        {
            // Use Syringe
            health.changeMentalState(20);
            syringes--;
            syringesUI.text = syringes.ToString();
        }
    }



    public void addSynringe()
    {
        syringes++;
        syringesUI.text = syringes.ToString();
    }

    public void addSynringe(int nb)
    {
        syringes += nb;
        syringesUI.text = syringes.ToString();
    }

    public void addPills()
    {
        pills++;
        pillsUI.text = pills.ToString();
    }

    public void addPills(int nb)
    {
        pills += nb;
        pillsUI.text = pills.ToString();
    }

    public void addCard()
    {
        haveCard = true;
    }


}
