﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class playerHealthMananger : MonoBehaviour
{
    private GameObject gm;
    private GameObject audioSource;

    [Header("Health Variables")]
    public float startHealth = 100f;
    public float health;
    public Image healthBar;

    public GameObject bloodEffect;

    private float deathCount;

    public Vector3 respawnLocation;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");

        health = startHealth;
        deathCount = 0;
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
        GameObject bloodFX = (Instantiate(bloodEffect, transform.position, Quaternion.identity)) as GameObject;
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
        Destroy(bloodFX, 2f);
    }

    public void HealthUp(float healAmount)
    {
        gm.GetComponent<AudioManager>().PlaySound("Health Pickup");
        health += healAmount;

        healthBar.fillAmount = health / startHealth;
    }

    public void Die()
    {
        deathCount++;
        Debug.Log("Bang Bang!! You Died!");

        // Player Respawn //
        transform.position = respawnLocation;
        // reset health //
        // reset ammo //
		health = startHealth;
		healthBar.fillAmount = health / startHealth;
        // Death Count Analytics //
        Analytics.CustomEvent("Player Death Count", new Dictionary<string, object>
        {
            { "Died", deathCount}
        }); 
    }

	public void NewSpawnPoint(Vector3 newSpawnPoint){

		respawnLocation = newSpawnPoint;
	}
}
