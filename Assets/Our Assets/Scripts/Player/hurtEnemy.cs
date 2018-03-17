using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public float damageAmount;

    public void OnTriggerEnter(Collider other)
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
    }

}
