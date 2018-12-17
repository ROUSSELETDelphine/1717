using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalHealthManager : MonoBehaviour {

    private Controller controller;               // Player controller script
    private GlitchHandler glitchHandler;
    public int startingMentalHealth = 0;        // Mental health at the beginning of the level
    public int currentMentalState;             // Current mental health state
    private bool isDead = false;                // Indicates whether the player is dead or not


    void Start () {
        currentMentalState = startingMentalHealth;
        controller = GetComponent<Controller>();
        glitchHandler = GameObject.FindWithTag("MainCamera").GetComponent<GlitchHandler>();
        
    }
	
	void Update () {
        /*if (controller != null && glitchHandler != null)
        {
            changeMentalState(0);
        }*/
	}

    public void changeMentalState(int amount)
    {
        currentMentalState += amount;

        if (currentMentalState <= -100 || currentMentalState >= 100)
        {
            gameOver();
        }

        if (currentMentalState >= -20 && currentMentalState < 20)
        {
            // Regular state
            controller.speed = 1.0f;
            glitchHandler.regularScreen();
        }
        else if (currentMentalState <= -90)
        {
            // Critical state of Fear
            controller.speed = 1.0f;
            glitchHandler.criticalStateScreen();

        } else if (-90 <= currentMentalState && currentMentalState < -50)
        {
            // Worrying state of Fear
            controller.speed = 1.0f;
            glitchHandler.worryingStateScreen();

        } else if (-50 <= currentMentalState && currentMentalState < -20) 
        {
            // First symptoms of Fear
            controller.speed = 1.0f;
            glitchHandler.firstSymptomsScreen();

        } else if (20 <= currentMentalState && currentMentalState < 50)
        {
            // First symptoms of Euphoria
            controller.speed = 2.0f;
            glitchHandler.regularScreen();

        } else if (50 <= currentMentalState && currentMentalState < 90)
        {
            // Worrying state of Euphoria
            controller.speed = 5.0f;
            glitchHandler.regularScreen();

        } else
        {
            // Critical state of Euphoria
            controller.speed = 10.0f;
            glitchHandler.regularScreen();

        } 
    }

    void gameOver()
    {
        print("You woke up because of the strong emotions starting to overwhelm you.");
    }
}
