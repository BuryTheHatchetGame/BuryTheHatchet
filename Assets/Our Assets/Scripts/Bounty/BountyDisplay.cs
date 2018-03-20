using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class BountyDisplay : MonoBehaviour {

//Gamemanager
	private GameObject GM;

	public Bounty bounty;

	private int currentBountyListNum = 0;

	//--Below, public variables that change depending on the Bounty(Scriptable Object). currently public for debugging.
	public Text bountyNameText;
	public Text bountyDescription;

	public Image bountyImage;

	public Text bountyRewardText;
	public int rewardFromBounty;
//-----------------------------------------------------------------------------------------------------------------------//

	public GameObject acceptButton;

	public GameObject targetBounty;

//Bounty spawn locations
	private Vector3 spawnLocation;

	//creates a list in the inspector, able to place Bounty(Scriptable Object) in list.
	public List <Bounty> bountyList = new List <Bounty> ();

	private GameObject newBounty;
	// Use this for initialization
	void Start () {
		currentBounty ();
		GM = GameObject.FindGameObjectWithTag ("GameController");
	}

	//Below function, fills out all the variables on the bountyDisplay taking the information from the Bounty(Scriptable Object).
	//Also fills out where the bountyTarget will spawn.
	 void currentBounty(){
		
		bounty = bountyList [currentBountyListNum];
		bountyNameText.text = bounty.bountyName;
		bountyDescription.text = bounty.bountyDescription;

		bountyImage.sprite = bounty.bountyImage;

		bountyRewardText.text = bounty.bountyRewardAmount.ToString();
		rewardFromBounty = bounty.bountyRewardAmount;

		spawnLocation = bounty.spawnBountyLocation;
		targetBounty = bounty.bountyTarget;

		//Below the object is spawning a prefab, naming it to current bounty name, and set the object false.
		newBounty = Instantiate (targetBounty, spawnLocation, Quaternion.identity);
		newBounty.name = bounty.bountyName;
		newBounty.SetActive (false);
//		bountyNameText.text = bounty.bountyName;
//		bountyDescription.text = bounty.bountyDescription;
//
//		bountyImage.sprite = bounty.bountyImage;
//		
//		bountyRewardText.text = bounty.bountyRewardAmount.ToString ();
	}

	//once this function has been called upon, the current bountyTarget will be visible to the player.
	public void acceptBounty(){
		Debug.Log ("Anything");
		newBounty.SetActive (true);
		acceptButton.SetActive (false);

        Analytics.CustomEvent("Bounty Accepted", null);

    }

	//once this function has been called upon, a new bounty is called.
	public void createNextBounty(){
		
		if (currentBountyListNum <= 1) {
			//currentBountyListNum = currentBountyListNum + 1;
			//GM.GetComponent<GameManager>().addCash(rewardFromBounty);
			currentBountyListNum++;
			Debug.Log (currentBountyListNum);
			acceptButton.SetActive (true);
			currentBounty ();
		}
	}


	//once this function has been called upon, the player gets the reward from killing the bountyTarget
	public void bountyReward(){
		GM.GetComponent<GameManager>().addCash(rewardFromBounty);
	}
}
