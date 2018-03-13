using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPlayer : MonoBehaviour
{
    public float healAmount;
    public GameObject thePlayer;

    public void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (thePlayer.GetComponent<playerHealthMananger>().health >= 100)
            {
                return;
            }
            else
            {
                other.GetComponent<playerHealthMananger>();
                Heal();
            }
            
        }
    }

    public void Heal()
    {
        thePlayer.GetComponent<playerHealthMananger>().HealthUp(healAmount);
        Destroy(this.gameObject);
    }
}
