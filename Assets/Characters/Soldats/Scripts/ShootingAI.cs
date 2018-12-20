using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour {

    private GameObject player;
    public GameObject weapon;
    public GameObject soldier;
    private NavMeshAgent myNavMeshAgent;
    private Collider[] hitColliders;
    private float checkRate;
    private float nextCheck;
    public LayerMask detectionLayer;

    private float distanceToPlayer;
    private float detectionRadius = 10; 
    private float maxRange = 10;
    private float minRange = 3;
    private float rotatingSpeed = 350;
    private float moveSpeed = 5;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
    }
	
	// Update is called once per frame
	void Update () {
        CheckIfPlayerInRange();
	}

    void LookAtPlayer()
    {
        Vector3 lookRotation = hitColliders[0].transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation), rotatingSpeed * Time.deltaTime);
    }

    void Attack()
    {
        weapon.SendMessageUpwards("RemoteFire", SendMessageOptions.DontRequireReceiver);
    }

    void SetInitialReferences()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.1f, 0.3f);
        player = GameObject.FindGameObjectWithTag("Team2");
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }

    void CheckIfPlayerInRange()
    {
        if (Time.time > nextCheck && myNavMeshAgent == true)
        {
            nextCheck = Time.time + checkRate;
            

            hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

            // Things are detected in detection range
            if (hitColliders.Length > 0)
            {
                // Player is detected, the soldier aims
                soldier.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);

                // Soldier rotates to look at the player then starts shooting
                distanceToPlayer = Vector3.Distance(hitColliders[0].transform.position, transform.position);
                LookAtPlayer();
                Attack();

                if (distanceToPlayer > minRange)
                {
                    // The player is too far from the soldier to shoot, the soldier moves towards the player.
                    //hitColliders[0] is the player
                    //the agent stoppes moving at "stopping distance" public attribute
                    myNavMeshAgent.SetDestination(hitColliders[0].transform.position);
                    soldier.SendMessageUpwards("SetBooleanTrue", "isMovingForward", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    // The soldier does not move 
                    soldier.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
                }
            }
            else
            {
                // Nothing is detected, the soldier does not aim
                soldier.SendMessageUpwards("SetBooleanFalse", "isAiming", SendMessageOptions.DontRequireReceiver);
                // The soldier does not move 
                soldier.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
}
