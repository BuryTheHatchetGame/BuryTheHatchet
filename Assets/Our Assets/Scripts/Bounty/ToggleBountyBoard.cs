using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBountyBoard : MonoBehaviour {

	public GameObject interactTextBubble;

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
		//interactTextBubble = GameObject.FindGameObjectWithTag ("InteractTextBubble");
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			interactTextBubble.SetActive (true);
		}
	}

	//if other gameobject staying within this gameobjects collider is tagged "Player" it will allow the player to press "E" to set toggleBountyBoard to true.
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if (Input.GetKey (KeyToPress)) {
				Time.timeScale = 0;
				toggleBountyBoard.SetActive	(true);
			
			}
		}

	}

	//if other gameobject tagged "Player" leaves this gameobjects collider, toggleBountyBoard = false.
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			toggleBountyBoard.SetActive (false);
			interactTextBubble.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//if function is called upon, toggleBountyBoard = false.
	public void ExitButton(){
		toggleBountyBoard.SetActive (false);
		Time.timeScale = 1;

	}
}