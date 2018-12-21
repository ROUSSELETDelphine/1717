using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalDoorScript : MonoBehaviour {

    public levelScript level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		if (level.levelCompleted)
        {
            SceneManager.LoadScene(4);
        }
	}
}
