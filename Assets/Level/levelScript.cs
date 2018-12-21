using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScript : MonoBehaviour {

    public AudioSource source;
    public GameObject finalDoor;
    public GameObject elevatorDoor;
    public float finalDoorRadius = 5;
    private Collider[] hitColliders;
    public LayerMask detectionLayer;
    private int nbInitialEnemies;
    private int nbBossEnemies;
    private bool bossHasSpawn = false;
    public bool levelCompleted = false;

	// Use this for initialization
	void Start () {
        nbInitialEnemies = transform.Find("Enemies").transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
        nbInitialEnemies = transform.Find("Enemies").transform.childCount;
        nbBossEnemies = transform.Find("Boss").Find("Enemy spawn").childCount;

        if (nbInitialEnemies <= 0 && !bossHasSpawn)
        {
            source.PlayOneShot(source.clip);   
            transform.Find("Boss").Find("Enemy spawn").SendMessage("SpawnObject", SendMessageOptions.DontRequireReceiver);
            bossHasSpawn = true;
            elevatorDoor.SetActive(false);
        }

        // If all enemies are dead and player is close to the final door
        if (nbInitialEnemies <= 0 && nbBossEnemies <= 0 && !levelCompleted)
        {
            levelCompleted = true;
        }
    }
}
