using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool bountyActive;
	public GameObject[] enemyControllers;
	public int playerCashAmount;
	public Text playerCashAmountText;

	private int playerCurrentAmmoAmount;
	public Text playerCurrentAmmoAmountText;



	// Use this for initialization
	void Start () {
		enemyControllers = GameObject.FindGameObjectsWithTag ("Enemy");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//AddThis ();
		//Debug.Log (playerCashAmount);
	}

	public void addCash(int addCashAmmount){

		playerCashAmount = playerCashAmount + addCashAmmount;
		playerCashAmountText.text = "Cash $:" + playerCashAmount.ToString ();

	}

	public void lessCash(int lessCashAmmount){
		playerCashAmount = playerCashAmount - lessCashAmmount;
	}

//	void AddThis(){
//		int cashAmmount = 2;
//		addCash (cashAmmount);
//	}

	void bountyAvailableCheck(){
		if (bountyActive = false) {
			//bountyAvailable
		}

	}

	//once this function is called upon, bountyActive = true.
	public void bountyAccepted(){
		bountyActive = true;
	}
	//once this function is called upon, bountyActive = false.
	public void bountyComplete(){
		bountyActive = false;
	}


//	public void resetEnemyControllerLists(){
//
//		enemyControllers = GameObject.FindGameObjectsWithTag ("Enemy");
//		foreach (GameObject enemy in enemyControllers) {
//			enemy.GetComponent<tempEnemyController> ().resetList ();
//		}
//
//
//	}

	//once this function is called upon, it removes the latest enemy to die from enemyList in all enemyController Scripts.
	public void removeEnemyFromList(GameObject currentRemoval){
		GameObject toRemove = currentRemoval;
		enemyControllers = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemyControllers) {
			enemy.GetComponent<tempEnemyController> ().removeFromList (toRemove);
		}

	}
}
