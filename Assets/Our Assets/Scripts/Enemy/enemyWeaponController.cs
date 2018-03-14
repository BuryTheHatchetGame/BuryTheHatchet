using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponController : MonoBehaviour
{
    [Header("Weapon Variables")]
    public Weapon weapon;
    public int damage;

    public GameObject bullet;
    public GameObject barrel;

    // Use this for initialization
    void Start()
    {
        damage = weapon.weaponDamageAmount;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    
}
