using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToggle : MonoBehaviour {

	public GameObject interactTextBubble;

	public enum ToggleType{ turnOn, turnOff, toggle }

	public GameObject toggleObject;
	public ToggleType toggleType;

	void Start(){
		interactTextBubble.SetActive (false);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		
		if (other.tag == "Player")
		{
			interactTextBubble.SetActive (true);
			if (Input.GetKey (KeyCode.E)) {
				if (toggleType == ToggleType.turnOn)
					toggleObject.SetActive (true);
				else if (toggleType == ToggleType.turnOff)
					toggleObject.SetActive (false);
				else if (toggleType == ToggleType.toggle)
					toggleObject.SetActive (!toggleObject.activeSelf);
			}
		}
		
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Player") {
			interactTextBubble.SetActive (false);
		}
	}
}
