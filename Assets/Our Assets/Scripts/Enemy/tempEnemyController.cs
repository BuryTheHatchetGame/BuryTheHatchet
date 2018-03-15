using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tempEnemyController : MonoBehaviour
{

	public float speed;

	public float stoppingDistance;

	public float retreatDistance;

	public float enemyAvoidDistance;
	//public NavMeshAgent nma;

    public float radiusSize;
	//float lockPos = 0;

	// Reference to the Player GameObject //
	private GameObject playerGO;
	// Reference to the Player's Transform //
	private Transform playerT;

	public List <GameObject> enemyList;
	// Use this for initialization
	void Start ()
    {
//		nma = GetComponent<NavMeshAgent> ();
		addToEnemyList();
		playerGO = GameObject.FindGameObjectWithTag("Player");
		playerT = playerGO.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveTowardsPlayerEnemyMovement ();
		AvoidOtherEnemies ();
//		transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);
//
//		if (Vector3.Distance (playerT.position, transform.position) <= radiusSize) 
//		{
//
//			//transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);
//			//transform.rotation.y = 0;
//			nma.SetDestination (playerT.position);
//		}

		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusSize);
    }

	void MoveTowardsPlayerEnemyMovement(){
		
		if (Vector3.Distance (transform.position, playerT.position) > stoppingDistance) {
			transform.position = Vector3.MoveTowards (transform.position, playerT.position, speed * Time.deltaTime);

		} else if (Vector3.Distance (transform.position, playerT.position) < stoppingDistance && Vector3.Distance (transform.position, playerT.position) > retreatDistance) {
			transform.position = this.transform.position;

		} else if (Vector3.Distance (transform.position, playerT.position) < retreatDistance) {
			transform.position = Vector3.MoveTowards (transform.position, playerT.position, -speed * Time.deltaTime);
		}

	}

	void AvoidOtherEnemies(){
		Vector3 EnemyT;

		foreach (GameObject enemy in enemyList) {
			EnemyT = enemy.transform.position;
			if (Vector3.Distance (transform.position, EnemyT) < enemyAvoidDistance) {
				transform.position = Vector3.MoveTowards (transform.position, EnemyT, -speed * Time.deltaTime);
			}
		}
	}
			

	public void resetList(){
		enemyList = new List <GameObject> ();
		enemyList.Clear ();
//		addToEnemyList ();
	}

	void addToEnemyList(){
		enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
	}
}
