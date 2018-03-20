using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 gunPos;

    public float angle;

    public void Update()
    {
       if (transform.localScale.x == 1)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.25f;

            Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - gunPos.x;
            mousePos.z = mousePos.z - gunPos.z;

            float angle = Mathf.Atan2(mousePos.z, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        }
        else if (transform.localScale.x == -1)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = 5.23f; // if breaks change back to mouse pos .z

            Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - gunPos.x;
            mousePos.z = mousePos.z - gunPos.z;

            float angle = Mathf.Atan2(mousePos.z, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        }
    }

    //public GameObject thisOneSpins;
    //public GameObject gunSprite;
    //private SpriteRenderer gunSpriteRend;

    //// Use this for initialization
    //void Start () {
    //	gunSpriteRend = gunSprite.GetComponent<SpriteRenderer>();
    //}

    //// Update is called once per frame
    //void Update () {
    //	faceTowards ();
    //	flipGunSprite ();

    //}

    //void faceTowards(){
    //	Vector2 mousePosition = Input.mousePosition;
    //	mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

    //       Vector2 direction = new Vector2(
    //           mousePosition.x - transform.position.z,
    //           mousePosition.y - transform.position.y
    //	);

    //	transform.up = direction;
    //}


    //void flipGunSprite(){
    //	if(thisOneSpins.transform.rotation.z > 0 ){
    //		gunSpriteRend.flipY = true;
    //	} else if (thisOneSpins.transform.rotation.z < 0){
    //		gunSpriteRend.flipY = false;
    //	}


    //}
}
