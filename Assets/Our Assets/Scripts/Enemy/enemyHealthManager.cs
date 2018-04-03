using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class enemyHealthManager : MonoBehaviour
{
    [Header("Health Variables")]
    public float startingHealth = 100f;
    public float health;

	private GameObject GM;

	public GameObject bountyBoard;

    private float deathCounter;


	// Use this for initialization
	void Start ()
    {
        deathCounter = 0;

        health = startingHealth;
		GM = GameObject.FindGameObjectWithTag ("GameController");

		bountyBoard = GameObject.FindGameObjectWithTag ("BountyBoard");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        // If Health is greater to equal to 100, health equals 100 //
        if (health >= 100)
        {
            health = 100;
        }

        if (health <= 0)
        {
            health = 0;
        }

	}

    public void GetHit(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // ANALYTICS - Enemy Deaths Counter //
        Analytics.CustomEvent("Enemy Death Counter", new Dictionary<string, object>
        {
            {"Enemies Killed", deathCounter}
        });
        


		//storing the gameobject as a variable i can access in the the gamemanager script, for removeEnemyFromList function.
		GameObject currentRemoval = this.gameObject;

		Vector3 enemyDeathSpot = this.gameObject.transform.position;
		GM.GetComponent<GameManager> ().enemyDropped (enemyDeathSpot);
        Debug.Log("Dead");
		//calls upon gamemanager script function(removeEnemyFromList).
		GM.GetComponent<GameManager> ().removeEnemyFromList (currentRemoval);

		//If the enemy that dies is a Boss(Tag) it will call upon two functions(bountyReward) & (createNextBounty) from the bountyDisplay Script.
		if (this.gameObject.tag == "Boss") {
			GM.GetComponent<BountyDisplay> ().bountyReward ();
			GM.GetComponent<BountyDisplay> ().createNextBounty ();
		
		}

        Destroy(this.gameObject);

		//this calls upon the function found in Game Manager to reset the enemyLists
		//GM.GetComponent<GameManager> ().resetEnemyControllerLists ();
    }


}
