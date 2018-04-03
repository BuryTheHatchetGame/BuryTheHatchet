using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBountyBoard : MonoBehaviour {

	public GameObject interactTextBubble;

	public string interactButtonDescription;

	public GameObject playerGunHolder;

	//Game Object you would like to turn on.
	public GameObject toggleBountyBoard;

	//Change the Key to Press in the inspector
	public KeyCode KeyToPress = KeyCode.E;

	//Place your player character within this gameobject
	public GameObject player;

	private bool bountyboardAccess;

	//Initially sets the object you'd like to turn on, off.
	void Start () {
		toggleBountyBoard.SetActive (false);
		interactTextBubble.SetActive (false);
		bountyboardAccess = false;

		//interactTextBubble = GameObject.FindGameObjectWithTag ("InteractTextBubble");
	}

	void Update(){
		turnBountyBoardOn ();

	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			playerGunHolder.GetComponent<weaponController> ().ShootIsAllowed();
			interactTextBubble.SetActive (true);
			bountyboardAccess = true;
		}
	}

	//if other gameobject staying within this gameobjects collider is tagged "Player" it will allow the player to press "E" to set toggleBountyBoard to true.
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			bountyboardAccess = true;
		}

	}

	void turnBountyBoardOn(){
		if(bountyboardAccess == true){
			if (Input.GetKey (KeyToPress)) {
				Time.timeScale = 0;
				//playerGunHolder.GetComponent<weaponController> ().ShootIsAllowed();
				toggleBountyBoard.SetActive	(true);

			}

		}

	}

	//if other gameobject tagged "Player" leaves this gameobjects collider, toggleBountyBoard = false.
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			bountyboardAccess = false;
			interactTextBubble.SetActive (false);
			playerGunHolder.GetComponent<weaponController> ().ShootIsAllowed();
			Time.timeScale = 1;
		}
	}

	//if function is called upon, toggleBountyBoard = false.
	public void ExitButton(){
		toggleBountyBoard.SetActive (false);
		toggleBountyBoard.SetActive (false);
		Time.timeScale = 1;

	}
}