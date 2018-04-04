using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlockPlayer : MonoBehaviour {


	public GameObject toggleObject;



	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.tag == "Player")
		{
			toggleObject.SetActive (true);

		}
		
	}



}
