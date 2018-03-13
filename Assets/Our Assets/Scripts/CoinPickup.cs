using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int addCoinAmmount;
	private GameObject GM;

	void Start(){
		GM = GameObject.FindGameObjectWithTag ("GameController");
	}

//	void FixedUpdate(){
//		GM.GetComponent<GameManager>().addCash(addCoinAmmount);
//	}

	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Player") {
			
			GM.GetComponent<GameManager>().addCash(addCoinAmmount);

		}
	}


}
