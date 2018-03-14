using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody bulletRB;

	// Use this for initialization
	void Start ()
    {
        bulletRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void Move()
    {
        Debug.Log("Bullet Moving...");
        //transform.position += Vector3.forward.normalized * movementSpeed * Time.deltaTime;

    }
}
