using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool bountyActive;

	public int playerCashAmount;
	public Text playerCashAmountText;

	private int playerCurrentAmmoAmount;
	public Text playerCurrentAmmoAmountText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//AddThis ();
		//Debug.Log (playerCashAmount);
	}

	public void addCash(int addCashAmmount){

		playerCashAmount = playerCashAmount + addCashAmmount;
		playerCashAmountText.text = "cash amount: " + playerCashAmount.ToString ();

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

	public void bountyAccepted(){
		bountyActive = true;
	}

	public void bountyComplete(){
		bountyActive = false;
	}


}
