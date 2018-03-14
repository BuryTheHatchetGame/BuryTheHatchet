using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthMananger : MonoBehaviour
{
    [Header("Health Variables")]
    public float startHealth = 100f;
    public float health;
    public Image healthBar;

	// Use this for initialization
	void Start ()
    {
        health = startHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If Health is greater to equal to 100, health equals 100 //
		if (health >= 100)
        {
            health = 100;
        }

        // If Health is less than or equal to 0, health equals  //
        if (health <= 0)
        {
            health = 0;
        }
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void HealthUp(float healAmount)
    {
        health += healAmount;

        healthBar.fillAmount = health / startHealth;
    }

    public void Die()
    {
        Debug.Log("Bang Bang!! You Died!");
    }
}
