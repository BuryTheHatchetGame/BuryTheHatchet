using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponController : MonoBehaviour
{
    private GameObject gm;
    private GameObject audioSource;

    [Header("Weapon Variables")]
    public Weapon weapon;
    public int damage;


	public float shotTimerMin;
	public float shotTimerMax;
	public float countDown;

	public float reloadTimer;
	private bool doReload;

	public float enemyClipAmount;
	public float originalClipAmount;

    public GameObject bullet;
	public float bulletSpeed = 10;

    public GameObject barrel;

	public enemyController eC;

	public GameObject playerGO;
	public Transform playerT;

    // Use this for initialization
    void Start()
	{
        gm = GameObject.FindGameObjectWithTag("GameController");

		playerGO = GameObject.FindGameObjectWithTag("Player");
		playerT = playerGO.transform;

		eC = GetComponentInParent<enemyController> ();
        damage = weapon.weaponDamageAmount;
		//fireRate = weapon.fireRate;

		countDown = Random.Range(shotTimerMin, shotTimerMax);
		enemyClipAmount = originalClipAmount;

		doReload = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		countDown -= Time.deltaTime;

		if (Vector3.Distance (playerT.position, transform.position) <= eC.radiusSize && countDown <= 0) 
		{
			Shoot ();

		}

		if (countDown <= 0) 
		{
			countDown = Random.Range(shotTimerMin, shotTimerMax);
		}

		if (doReload == true) {
			reloadTimer -= Time.deltaTime;
		}


	}

	public void Shoot()
	{
		//Debug.Log("Shoot gun at Player");
		// DEBUG - REMOVE LATER //
		Debug.Log("Bullet Moving...");
		if (enemyClipAmount > 0) {

			gm.GetComponent<AudioManager> ().PlaySound ("Shoot");
			// Spawn Bullet + Add Force //
			GameObject Bullet = Instantiate (bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
			Bullet.GetComponent<Rigidbody2D> ().AddForce (barrel.transform.right * bulletSpeed, ForceMode2D.Impulse);

			enemyClipAmount = enemyClipAmount - 1;
			// Destroy Bullet After 3 Seconds //
			Destroy (Bullet, 3f);

		} else if (enemyClipAmount == 0) {
			doReload = true;
			reload ();
		}

	}

	public void reload(){

			if (reloadTimer <= 0) {

                gm.GetComponent<AudioManager>().PlaySound("Reload");

                // Reload Weapon //
                Debug.Log ("RELOADING...");
				enemyClipAmount = originalClipAmount;


				doReload = false;
				Debug.Log (doReload);

			}
		}

    
}
