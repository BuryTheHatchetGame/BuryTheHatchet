using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tempEnemyController : MonoBehaviour
{

	public float speed;

	public float seePlayer;

	public float stoppingDistance;

	public float retreatDistance;

	public float enemyTakeCoverDistance;

	public float enemyAvoidDistance;
	//public NavMeshAgent nma;

    public float radiusSize;
	//float lockPos = 0;

	// Reference to the Player GameObject //
	private GameObject playerGO;
	// Reference to the Player's Transform //
	private Transform playerT;

	public List <GameObject> enemyList;

	public List <GameObject> rockList;

	// Use this for initialization
	void Start ()
    {
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemyList.Add (enemy);
		}

		foreach (GameObject rock in GameObject.FindGameObjectsWithTag("Rock")) {
			rockList.Add (rock);
		}
//		nma = GetComponent<NavMeshAgent> ();
		//addToEnemyList();
		playerGO = GameObject.FindGameObjectWithTag("Player");
		playerT = playerGO.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		AvoidOtherEnemies ();
		MoveTowardsPlayerEnemyMovement ();
		//enemyTakeCover ();


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
		//checks distance between this gameobject and playerT, if less then seePlayer float the rest if the function can be used by the script.
		if (Vector3.Distance (transform.position, playerT.position) < seePlayer) {


			// checks distance between this.gameobject.position and playerT.position if it is bigger then the stopping distance this.gameobject will proceed to move towards playerT.position
			if (Vector3.Distance (transform.position, playerT.position) > stoppingDistance) {
				transform.position = Vector3.MoveTowards (transform.position, playerT.position, speed * Time.deltaTime);


				// checks distance between this.gameobject.position and playerT.position if it is less then the stopping distance & more then retreatDistance, this gameobject will stand still.
			} else if (Vector3.Distance (transform.position, playerT.position) < stoppingDistance && Vector3.Distance (transform.position, playerT.position) > retreatDistance) {
				transform.position = this.transform.position;
				//enemyTakeCover ();



				// checks distance between this.gameobject.position and playerT.position if it is less then the retreatDistance, this gameobject will move away from playerT.position.
			} else if (Vector3.Distance (transform.position, playerT.position) < retreatDistance) {
				transform.position = Vector3.MoveTowards (transform.position, playerT.position, -speed * Time.deltaTime);
			}
				
		}

		

	}

	void AvoidOtherEnemies(){
		Vector3 EnemyT;

		//checks the distance between this.gameobject and every other gameobject tagged "Enemy". If less then enemyAvoidDistance, this gameobject will move away.
		foreach (GameObject enemy in enemyList) {
			EnemyT = enemy.transform.position;
			if (Vector3.Distance (transform.position, EnemyT) < enemyAvoidDistance) {
				transform.position = Vector3.MoveTowards (transform.position, EnemyT, -speed * Time.deltaTime);
			}
		}
	}

	void enemyTakeCover(){
		Vector3 RockT;

		foreach (GameObject rock in rockList) {
			RockT = rock.transform.position;
			if (Vector3.Distance (transform.position, RockT) < enemyTakeCoverDistance) {
				transform.position = Vector3.MoveTowards (transform.position, RockT, speed * Time.deltaTime);
			}
		}
	}



			
//	//
//	public void resetList(){
//		//enemyList = new List <GameObject> ();
//		//enemyList.Clear();
//		//addToEnemyList ();
//	}


	//adds GameObjects tagged with "Enemy" to the enemyList.
//	void addToEnemyList(GameObject enemyToAdd){
//		enemyList.Add(enemyToAdd);
//		
//	}

	//called upon from gamemanager script to remove this gameobject from the enemyList each enemy carries.
	public void removeFromList(GameObject toRemove){
		enemyList.Remove (toRemove);
	}

}
