using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public GameObject playerTarget;
    private Transform playerTransform;
	// Use this for initialization
	void Start ()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerTarget.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
       // Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, this.transform.position.y, playerTarget.transform.position.z);
        this.transform.LookAt(playerTransform);
    }

    
}
