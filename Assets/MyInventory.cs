using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyInventory : MonoBehaviour
{
    private MentalHealthManager health;
    public int syringes;
    public int pills;
    public bool haveCard;

    void Start()
    {
        health = gameObject.GetComponent<MentalHealthManager>();
        //syringes = 0;
        //pills = 0;
        haveCard = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && pills > 0)
        {
            // Use Pills
            health.changeMentalState(-20);
            pills--;
        }
        if (Input.GetKeyDown(KeyCode.V) && syringes > 0)
        {
            // Use Syringe
            health.changeMentalState(20);
            syringes--;
        }
    }



    public void addSynringe()
    {
        syringes++;
    }

    public void addSynringe(int nb)
    {
        syringes += nb;
    }

    public void addPills()
    {
        pills++;
    }

    public void addPills(int nb)
    {
        pills += nb;
    }

    public void addCard()
    {
        haveCard = true;
    }


}
