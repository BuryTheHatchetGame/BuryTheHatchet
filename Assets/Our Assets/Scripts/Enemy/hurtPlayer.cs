using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour
{
    public GameObject thePlayer;
    public float damageAmount;

    // Use this for initialization
    void Start()
    {
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
        thePlayer.GetComponent<playerHealthMananger>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HurtPlayer(damageAmount);
        }
    }

    public void HurtPlayer(float damageAmount)
    {
        thePlayer.GetComponent<playerHealthMananger>().TakeDamage(damageAmount);
    }
}
