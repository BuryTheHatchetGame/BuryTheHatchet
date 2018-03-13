using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bounty", menuName = "Bounty")]
public class Bounty : ScriptableObject {

	public string bountyName;
	public string bountyDescription;

	public Sprite bountyImage;

	public int bountyRewardAmount;

	public void Print(){
		Debug.Log (bountyName + " " + bountyDescription + " Reward: " + bountyRewardAmount);
	}
}
