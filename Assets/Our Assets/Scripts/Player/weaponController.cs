using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    [Header("Weapon Variables")]
    public Weapon weapon;
    public int damage;
    public int clipAmount;

    public GameObject bullet;
    // Barrel of the Gun, where the bullet is spawned from //
    public GameObject barrel;

    public float bulletSpeed = 10;

	// Use this for initialization
	void Start ()
    {
        damage = weapon.weaponDamageAmount;
        clipAmount = weapon.weaponClipAmount;

        Debug.Log (weapon.weaponName + ", Damage: " + weapon.weaponDamageAmount + ", Clip Amount: " + weapon.weaponClipAmount);
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShootGun();

        Reload();

    }

    public void ShootGun()
    {
        // If left click - Shoot // 
        if (Input.GetMouseButtonDown(0))
        {
            // PARTICLE EFFECT HERE //

            // INSTANTIATE BULLET HERE //
            if (clipAmount >0)
            {
                SpawnBullet();
                Debug.Log("BANG!");
                clipAmount--;
            }

        }

        if (clipAmount <= 0)
        {
            clipAmount = 0;

            // SHOW RELOAD UI HERE //

            Debug.Log("OUT OF AMMO...");
        }
    }

    public void Reload()
    {
        // If the player pressed "R" while ammo is 0 - Reload //
        if (clipAmount == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("RELOADING...");
                clipAmount = weapon.weaponClipAmount;
            }
        }

    }

    public void SpawnBullet()
    {

        Debug.Log("Bullet Moving...");

        GameObject Bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.right * bulletSpeed, ForceMode.Impulse);

        Destroy(Bullet, 3f);

    }
}
