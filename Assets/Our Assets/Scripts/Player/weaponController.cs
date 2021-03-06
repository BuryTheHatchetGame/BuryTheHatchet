﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponController : MonoBehaviour
{
    private GameObject gm;
    private GameObject audioSource;

	private bool countDownOn = false;

    [Header("Weapon Variables")]
    public Weapon weapon;
    public int damage;
    public int clipAmount;
    public int fireRate;
    public int reloadTime;

    public AudioSource audio;
    public AudioClip[] reloadSounds;

    public bool canReload = true;

    public bool shootAllowed = true;

    public Text playerCurrentAmmoAmountText;

    public float bulletSpeed = 10;

    // Reload Time //
    private float reloadCountDownStart;
    private float reloadCountDown;
	private float tempReloadCountDown;

	public float divideFloat = 2f;

    // Fire Rate Counter //
    private float countDownStart;
    private float countDown;

    [Header("Weapons 'Parts'")]
    public GameObject bullet;
    // Barrel of the Gun, where the bullet is spawned from //
    public GameObject barrel;

    [Header("Panels")]
    public GameObject reloadText;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GameController");

        damage = weapon.weaponDamageAmount;
        clipAmount = weapon.weaponClipAmount;
        fireRate = weapon.weaponFireRate;
        reloadTime = weapon.weaponReloadTime;

        playerCurrentAmmoAmountText.text = "AMMO: " + clipAmount.ToString();


        //fireRate = 10;

        countDown = fireRate + 1;

        reloadCountDown = reloadTime;

        // DEBUG - DELETE LATER //
        Debug.Log (weapon.weaponName + ", Damage: " + weapon.weaponDamageAmount + ", Clip Amount: " + weapon.weaponClipAmount + ", Fire Rate: " + weapon.weaponFireRate);

		reloadText.SetActive(false);
	}

    // Update is called once per frame
    void Update ()
    {
        countDown += Time.deltaTime;

        if (shootAllowed == true)
        {
            ShootGun();
        }

        //ReloadReload();

        //newCountdown ();

        //AutoReload();

        TempReload ();

        playerCurrentAmmoAmountText.text = "AMMO: " + clipAmount.ToString();

    }

    public void ShootGun()
    {
        // Left Click to Shoot  // 
        if (Input.GetMouseButtonDown(0))
        {
            // PARTICLE EFFECT HERE //

            // INSTANTIATE BULLET HERE //
            if (clipAmount > 0)
            {
                
                
                SpawnBullet();
                Debug.Log("BANG!");
                clipAmount--;

                countDown = countDownStart;
                //countDown = fireRate +1;
            }

        }

        // Hold left Click Down - Shoot according to Fire Rate //
        if (Input.GetMouseButton(0))        
        {
            //countDown += Time.deltaTime;
            // Fire Rate decrease //
            if (countDown >= weapon.weaponFireRate)
            { 
                if (clipAmount > 0)
                {
                    

                    SpawnBullet();
                    Debug.Log("BANG!");
                    clipAmount -= 1;
                }
                
                countDown = countDownStart;
            }

        }

        // EMPTY GUN //
        if (Input.GetKeyDown(KeyCode.R) && clipAmount <= 0)
        {
			reloadText.SetActive(true);
            clipAmount = 0;

            //gm.GetComponent<AudioManager>().PlaySound("Reload");

            // SHOW RELOAD UI HERE //
//            reloadText.SetActive(true);

            Debug.Log("OUT OF AMMO...");
        }



    }

//    public void AutoReload()
//    {
//        if (clipAmount <= 0)
//        {
//          reloadCountDown -= Time.deltaTime;
//
//            if (reloadCountDown <= 0)
//            {
//
//                // Reload Weapon //
//                Debug.Log("RELOADING...");
//                clipAmount = weapon.weaponClipAmount;
//
//                reloadPanel.SetActive(false);
//
//                reloadCountDown = weapon.weaponReloadTime;
//            }
//
//        }
//
//    }

	public void TempReload(){
		if (clipAmount == 0) {
			reloadText.SetActive (true);
		}
		//bool countDownOn;
		float tempClipAmount;
		//countDownOn = false;

		if ((Input.GetKeyDown (KeyCode.R) && (canReload == true))) 
        {

            // if (reloadCountDown <= 0)
            //{
            
                tempClipAmount = weapon.weaponClipAmount - clipAmount;
            ReloadSound();
                tempClipAmount = tempClipAmount / divideFloat;
                reloadCountDown = tempClipAmount;
                countDownOn = true;
            //}
            canReload = false;

        }

		if (countDownOn == true) {
			reloadText.SetActive (false);
			reloadCountDown -= Time.deltaTime;
		
	
			if (reloadCountDown <= 0) {

               

                // Reload Weapon //
                Debug.Log ("RELOADING...");
				clipAmount = weapon.weaponClipAmount;

				reloadText.SetActive (false);

				countDownOn = false;
				Debug.Log (countDownOn);

                canReload = true;
            }
		}

        
	}
		
    void ReloadSound()
    {
        audio.PlayOneShot(reloadSounds[clipAmount]);
    }


    public void SpawnBullet()
    {
        // DEBUG - REMOVE LATER //
        Debug.Log("Bullet Moving...");

        playerCurrentAmmoAmountText.text = "AMMO: " + clipAmount.ToString();

        // PLAY SHOOTING SOUND //
        gm.GetComponent<AudioManager>().PlaySound("Shoot");

        // Spawn Bullet + Add Force //
        GameObject Bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().AddForce(barrel.transform.right * bulletSpeed, ForceMode2D.Impulse);

        // Destroy Bullet After 3 Seconds //
        Destroy(Bullet, 3f);
    }

    public void ShootIsAllowed()
    {

        if (shootAllowed == false)
        {
            shootAllowed = true;
        }
        else if (shootAllowed == true)
        {
            shootAllowed = false;
        }
    }
}
