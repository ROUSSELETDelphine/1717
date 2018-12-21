using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScript : MonoBehaviour {
    
    private int nbEnemies;
    private bool bossHasSpawn = false;

	// Use this for initialization
	void Start () {
        nbEnemies = transform.Find("Enemies").transform.childCount;
        print(nbEnemies);
	}
	
	// Update is called once per frame
	void Update () {
        nbEnemies = transform.Find("Enemies").transform.childCount;

        if (nbEnemies <= 0 && !bossHasSpawn)
        {
            transform.Find("Boss").Find("Enemy spawn").SendMessage("SpawnObject", SendMessageOptions.DontRequireReceiver);
            bossHasSpawn = true;
        }
    }
}
