using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBossScript : MonoBehaviour {

	public GameObject bountyBoard;

	void Start(){
		bountyBoard = GameObject.FindGameObjectWithTag ("BountyBoard");
	}

//	void Update(){
//		bountyBoard = GameObject.FindGameObjectWithTag ("BountyBoard");
//	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			bountyBoard.GetComponent<BountyDisplay> ().createNextBounty ();
			Destroy (this.gameObject);
		
		}


	}

}
