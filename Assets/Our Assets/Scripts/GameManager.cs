using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private AudioManager audioManager;

    private GameObject gm;
    private GameObject audioSource;

	private GameObject currentBoss;

    public bool bountyActive;
	public GameObject[] enemyControllers;
	public int playerCashAmount;
	public Text playerCashAmountText;

	public GameObject healthPickup;
	public GameObject coinPickup;
	public GameObject cashPickup;

	// Use this for initialization
	void Start () {

        
        playerCashAmountText.text = "CASH: $" + playerCashAmount.ToString();

        gm = GameObject.FindGameObjectWithTag("GameController");

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager found in Scene");
        }

		enemyControllers = GameObject.FindGameObjectsWithTag ("Enemy");
	}

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
		//AddThis ();
		//Debug.Log (playerCashAmount);
	}

	public void addCash(int addCashAmmount){

        gm.GetComponent<AudioManager>().PlaySound("Coin Pickup");
		playerCashAmount = playerCashAmount + addCashAmmount;
		playerCashAmountText.text = "Cash "+ "$" + playerCashAmount.ToString ();

	}

	public void lessCash(int lessCashAmmount){
		playerCashAmount = playerCashAmount - lessCashAmmount;
	}

//	void AddThis(){
//		int cashAmmount = 2;
//		addCash (cashAmmount);
//	}

	//void bountyAvailableCheck(){
	//	if (bountyActive = false) {
	//		//bountyAvailable
	//	}

	//}

	//once this function is called upon, bountyActive = true.
	public void bountyAccepted(){
		bountyActive = true;
		currentBoss = GameObject.FindGameObjectWithTag ("Boss");
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
		//GameObject currentBoss = GameObject.FindGameObjectWithTag ("Boss");
		GameObject toRemove = currentRemoval;
		enemyControllers = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemyControllers) {
			enemy.GetComponent<tempEnemyController> ().removeFromList (toRemove);
		}

		if (bountyActive == true) {
			currentBoss.GetComponent<tempEnemyController> ().removeFromList (toRemove);
		}

		//currentBoss.GetComponent<tempEnemyController> ().removeFromList (toRemove);
	}

	//Drop Chance of 
	public void enemyDropped(Vector2 enemyDeathSpot){
		int randomNum;
		GameObject healthPack;
		GameObject coinPack;
		GameObject cashPack;


		randomNum = Random.Range (1, 5);

		if (randomNum == 1) {
			healthPack = Instantiate (healthPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log ("Health");
			Analytics.CustomEvent ("Health_Dropped", null);
		}

		if (randomNum == 2) {
			coinPack = Instantiate (coinPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log ("Coin");
			Analytics.CustomEvent ("Coin_Dropped", null);
		}

		if (randomNum == 3) {
			cashPack = Instantiate (cashPickup, enemyDeathSpot, Quaternion.identity);
			Debug.Log ("Cash");
			Analytics.CustomEvent ("Cash_Dropped", null);
		}

	}
}
