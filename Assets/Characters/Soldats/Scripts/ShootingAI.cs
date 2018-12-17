using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour {

    public GameObject player;
    public GameObject weapon;
    public GameObject soldat;   
    public float distanceToPlayer;
    public float maxRange = 15f;
    public float minRange = 10f;
    public float rotatingSpeed = 5f;
    public float moveSpeed = 5f;

	// Use this for initialization
	void Start () {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
            // Gerer plus tard l'angle de vue des soldats   
            LookAtPlayer();
            if (hit.collider.gameObject.name.Contains("Cube") == false && hit.collider.gameObject.name.Contains("Wall") == false)
            {
                if (distanceToPlayer < maxRange && distanceToPlayer > minRange)
                {
                    Attack();
                    LookAtPlayer();
                    soldat.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
                    soldat.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);
                    
                    
                }
                else
                {
                    LookAtPlayer();
                    Attack();
                    /*
                    Chase();
                    soldat.SendMessageUpwards("SetBooleanTrue", "isMovingForward", SendMessageOptions.DontRequireReceiver);
                    soldat.SendMessageUpwards("SetBooleanTrue", "isAiming", SendMessageOptions.DontRequireReceiver);
                    */
                }
            }

            else
            {
                soldat.SendMessageUpwards("SetBooleanFalse", "isMovingForward", SendMessageOptions.DontRequireReceiver);
                soldat.SendMessageUpwards("SetBooleanFalse", "isAiming", SendMessageOptions.DontRequireReceiver);
            }

        }
	}

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotatingSpeed);
    }

    void Chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    void Attack()
    {
        weapon.SendMessageUpwards("RemoteFire", SendMessageOptions.DontRequireReceiver);
    }
    
}
