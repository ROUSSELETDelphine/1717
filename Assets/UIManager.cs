using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject player;
    private MentalHealthManager healthManager;
    private Slider slider;
    private int mentalHealth;

    // Use this for initialization
    void Start () {
        healthManager = player.GetComponent<MentalHealthManager>();
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (slider != null && healthManager != null)
        {
            slider.value = healthManager.currentMentalState;
        }
        
	}
}
