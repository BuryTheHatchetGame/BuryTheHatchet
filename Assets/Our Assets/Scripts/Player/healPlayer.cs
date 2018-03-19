using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class healPlayer : MonoBehaviour
{
    public float healAmount;
    public GameObject thePlayer;

    private int healCounter;

    public void Start()
    {
        healCounter = 0;
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
        healCounter++;

        Analytics.CustomEvent("Player Heal Up", new Dictionary<string, object>
        {
            {"Healed Up", healCounter}
        });

        thePlayer.GetComponent<playerHealthMananger>().HealthUp(healAmount);
        Destroy(this.gameObject);
    }
}
