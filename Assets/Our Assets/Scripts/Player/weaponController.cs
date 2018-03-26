using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
	private bool countDownOn = false;

    [Header("Weapon Variables")]
    public Weapon weapon;
    public int damage;
    public int clipAmount;
    public int fireRate;
    public int reloadTime;

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
        damage = weapon.weaponDamageAmount;
        clipAmount = weapon.weaponClipAmount;
        fireRate = weapon.weaponFireRate;
        reloadTime = weapon.weaponReloadTime;

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

        ShootGun();

        //ReloadReload();

		//newCountdown ();

        //AutoReload();

		TempReload ();

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
        if (clipAmount <= 0)
        {
            clipAmount = 0;

            // SHOW RELOAD UI HERE //
			reloadText.SetActive(true);

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
		//bool countDownOn;
		float tempClipAmount;
		//countDownOn = false;

		if (Input.GetKeyDown (KeyCode.R)) {
			tempClipAmount = weapon.weaponClipAmount - clipAmount;
			tempClipAmount = tempClipAmount / divideFloat;
			reloadCountDown = tempClipAmount;
			countDownOn = true;
		
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
		
			}
		}

	}
		



    public void SpawnBullet()
    {
        // DEBUG - REMOVE LATER //
        Debug.Log("Bullet Moving...");

        // Spawn Bullet + Add Force //
        GameObject Bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().AddForce(barrel.transform.right * bulletSpeed, ForceMode2D.Impulse);

        // Destroy Bullet After 3 Seconds //
        Destroy(Bullet, 3f);
    }
}
