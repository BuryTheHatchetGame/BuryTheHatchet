using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BountyDisplay : MonoBehaviour {

	public Bounty bounty;

	public Text bountyNameText;
	public Text bountyDescription;

	public Image bountyImage;

	public Text bountyRewardText;


	// Use this for initialization
	void Start () {
		bountyNameText.text = bounty.bountyName;
		bountyDescription.text = bounty.bountyDescription;

		bountyImage.sprite = bounty.bountyImage;

		bountyRewardText.text = bounty.bountyRewardAmount.ToString ();
	}
	

}
