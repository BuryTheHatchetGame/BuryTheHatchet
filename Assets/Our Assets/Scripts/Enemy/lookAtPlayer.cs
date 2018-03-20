using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public GameObject playerTarget;
    private Transform playerTransform;

	private Vector2 playerVectorTwo;
	// Use this for initialization
	void Start ()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
		//playerTransform = playerTarget.transform.position;
		playerVectorTwo = new Vector2 (playerTarget.transform.position.x, playerTarget.transform.position.y);
	}
	
	// Update is called once per frame
	void Update ()
    {
		gunLookAtPlayer ();
        //Vector3 targetPosition = new Vector3(playerTarget.transform.position.x, this.transform.position.y, playerTarget.transform.position.z);
		//this.transform.LookAt(playerVectorTwo);
    }

	void gunLookAtPlayer(){
		Vector3 diff = playerTarget.transform.position - transform.position;
		//diff.Normalize ();

		float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.right = diff;

	}


    
}
