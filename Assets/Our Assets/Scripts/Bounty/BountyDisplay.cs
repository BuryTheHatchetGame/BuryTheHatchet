using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BountyDisplay : MonoBehaviour {

	public Bounty bounty;

	private int currentBountyListNum = 0;

	public Text bountyNameText;
	public Text bountyDescription;

	public Image bountyImage;

	public Text bountyRewardText;
	//public int rewardFrom
	public GameObject targetBounty;

	private Vector3 spawnLocation;

	public List <Bounty> bountyList = new List <Bounty> ();


	private GameObject newBounty;
	// Use this for initialization
	void Start () {
		currentBounty ();
	}
	
	 void currentBounty(){
		
		bounty = bountyList [currentBountyListNum];
		bountyNameText.text = bounty.bountyName;
		bountyDescription.text = bounty.bountyDescription;

		bountyImage.sprite = bounty.bountyImage;

		bountyRewardText.text = bounty.bountyRewardAmount.ToString();

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

	public void acceptBounty(){
		Debug.Log ("Anything");
		newBounty.SetActive (true);

	}

	public void nextBounty(){
		if (currentBountyListNum >= 0) {
			currentBountyListNum = currentBountyListNum + 1;
			currentBounty ();
		}
	}
}
