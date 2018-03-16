using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthManager : MonoBehaviour
{
    [Header("Health Variables")]
    public float startingHealth = 100f;
    public float health;

	private GameObject GM;




	// Use this for initialization
	void Start ()
    {
        health = startingHealth;
		GM = GameObject.FindGameObjectWithTag ("GameController");
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
		GameObject currentRemoval = this.gameObject;

        Debug.Log("Dead");
		GM.GetComponent<GameManager> ().removeEnemyFromList (currentRemoval);
        Destroy(this.gameObject);

		//this calls upon the function found in Game Manager to reset the enemyLists
		GM.GetComponent<GameManager> ().resetEnemyControllerLists ();
    }
}
