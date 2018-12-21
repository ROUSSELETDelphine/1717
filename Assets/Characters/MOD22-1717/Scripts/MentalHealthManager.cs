using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MentalHealthManager : MonoBehaviour {

    private Controller controller;               // Player controller script
    private GlitchHandler glitchHandler;        // Script that makes appear glitch on screen
    public float startingMentalHealth = 0.0f;        // Mental health at the beginning of the level
    public float currentMentalState;             // Current mental health state
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

    public void changeMentalState(float amount)
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
            controller.speed = 1.5f;
            glitchHandler.regularScreen();

        } else if (50 <= currentMentalState && currentMentalState < 90)
        {
            // Worrying state of Euphoria
            controller.speed = 2f;
            glitchHandler.regularScreen();

        } else
        {
            // Critical state of Euphoria
            controller.speed = 2.5f;
            glitchHandler.regularScreen();

        } 
    }

    void gameOver()
    {
        print("You woke up because of the strong emotions starting to overwhelm you.");
        SceneManager.LoadScene(2);
    }
}
