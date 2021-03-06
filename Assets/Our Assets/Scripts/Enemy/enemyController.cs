﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
	public NavMeshAgent nma;

    public float radiusSize;
	float lockPos = 0;

	// Reference to the Player GameObject //
	private GameObject playerGO;
	// Reference to the Player's Transform //
	private Transform playerT;

	// Use this for initialization
	void Start ()
    {
		nma = GetComponent<NavMeshAgent> ();

		playerGO = GameObject.FindGameObjectWithTag("Player");
		playerT = playerGO.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);

		if (Vector3.Distance (playerT.position, transform.position) <= radiusSize) 
		{

			//transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);
			//transform.rotation.y = 0;
			nma.SetDestination (playerT.position);
		}

	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusSize);
    }
}
