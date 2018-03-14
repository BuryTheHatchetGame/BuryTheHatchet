using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBossScript : MonoBehaviour {

	private GameObject bountyBoard;

	void Start(){
		bountyBoard = GameObject.FindGameObjectWithTag ("BountyBoard");
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (this.gameObject);
			bountyBoard.GetComponent<BountyDisplay> ().nextBounty ();
		}


	}

}
