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

	public List <Bounty> bountyList = new List <Bounty> ();

	// Use this for initialization
	void Start () {
		currentBounty ();
	}
	
	public void nextBounty(){
		if (currentBountyListNum <= 0) {
			currentBountyListNum = currentBountyListNum + 1;
			currentBounty ();
		}
	}
	public void currentBounty(){
		bounty = bountyList [currentBountyListNum];
		bountyNameText.text = bounty.bountyName;
		bountyDescription.text = bounty.bountyDescription;

		bountyImage.sprite = bounty.bountyImage;

		bountyRewardText.text = bounty.bountyRewardAmount.ToString();
			
//		bountyNameText.text = bounty.bountyName;
//		bountyDescription.text = bounty.bountyDescription;
//
//		bountyImage.sprite = bounty.bountyImage;
//		
//		bountyRewardText.text = bounty.bountyRewardAmount.ToString ();
	}
}
