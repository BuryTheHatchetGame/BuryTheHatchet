using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtEnemy : MonoBehaviour
{
    private GameObject theGun;

    public GameObject theEnemy;
    public int damageAmount;

    

    public void Start()
    {
        theGun = GameObject.FindGameObjectWithTag("PlayerGun");
        damageAmount = theGun.GetComponent<weaponController>().damage;
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<enemyHealthManager>().GetHit(damageAmount);
            Destroy(this.gameObject);
        }

		if (other.gameObject.tag == "Boss") {
			other.GetComponent<enemyHealthManager>().GetHit(damageAmount);
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "Enviroment") {
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Rock") {
			Destroy (this.gameObject);
		}
    }

}
