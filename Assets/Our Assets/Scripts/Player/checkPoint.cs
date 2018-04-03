using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour 
{
	public Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		spawnPoint = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.tag == "Player") {
			other.GetComponent<playerHealthMananger> ().NewSpawnPoint (spawnPoint);
		
		}

	}
}
