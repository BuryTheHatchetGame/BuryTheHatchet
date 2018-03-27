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
	public float shotTimer;
	public float countDown;

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

		countDown = shotTimer;
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
			countDown = shotTimer;
		}
	}

	public void Shoot()
	{
		//Debug.Log("Shoot gun at Player");
		// DEBUG - REMOVE LATER //
		Debug.Log("Bullet Moving...");

        gm.GetComponent<AudioManager>().PlaySound("Shoot");
		// Spawn Bullet + Add Force //
		GameObject Bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
		Bullet.GetComponent<Rigidbody2D>().AddForce(barrel.transform.right * bulletSpeed, ForceMode2D.Impulse);

		// Destroy Bullet After 3 Seconds //
		Destroy(Bullet, 3f);

	}
    
}
