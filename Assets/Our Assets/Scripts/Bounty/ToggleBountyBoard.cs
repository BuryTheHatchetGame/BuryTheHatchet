using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBountyBoard : MonoBehaviour {

	public Text interactButton;

	public string interactButtonDescription;

	//Game Object you would like to turn on.
	public GameObject toggleBountyBoard;

	//Change the Key to Press in the inspector
	public KeyCode KeyToPress = KeyCode.E;

	//Place your player character within this gameobject
	public GameObject player;


	//Initially sets the object you'd like to turn on, off.
	void Start () {
		toggleBountyBoard.SetActive (false);
	}
	

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyToPress)) {
				toggleBountyBoard.SetActive	(true);
			}
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			toggleBountyBoard.SetActive (false);
		}
	}

	public void ExitButton(){
		toggleBountyBoard.SetActive (false);

	}
}