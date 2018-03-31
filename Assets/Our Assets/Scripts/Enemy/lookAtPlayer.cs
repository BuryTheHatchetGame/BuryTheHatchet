using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{

	//enemy sprite gameobject
	public GameObject enemySprite;

	//enemy_revolver sprite gameobject
	public GameObject enemyRevolver;

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

		if (diff.x < .5f) {
			enemyRevolver.GetComponent<SpriteRenderer> ().flipY = true;
			enemySprite.GetComponent<SpriteRenderer>().flipX = true;
		} else if (diff.x > .5f) {
			enemyRevolver.GetComponent<SpriteRenderer> ().flipY = false;
			enemySprite.GetComponent<SpriteRenderer>().flipX = false;
		}

	}
		

//	void spriteFlip(){
//		Vector3 playerPos = Camera.main.ScreenToViewportPoint (playerTarget);
//		if (playerPos.x < .5f) {
//			enemyRevolver.GetComponent<SpriteRenderer> ().flipY = true;
//			enemySprite.GetComponent<SpriteRenderer>().flipX = true;
//		} else if (playerPos.x > .5f) {
//			enemyRevolver.GetComponent<SpriteRenderer> ().flipY = false;
//			enemySprite.GetComponent<SpriteRenderer>().flipX = false;
//		}
//
//	}

    
}
