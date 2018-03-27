using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Player Variables")]
    public float movementSpeed;
    public Rigidbody rb;



	//rayCastVariables
	public float addToRayCastStart;
	public float addToRayCastEnd;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        #region MoveLeft
        // LEFT MOVEMENT //
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Moving Left...");
            transform.position += Vector3.left.normalized * movementSpeed * Time.deltaTime;

        }
        #endregion

        #region MoveRight
        // RIGHT MOVEMENT //
//		RaycastHit2D hit = Physics2D.Linecast (new Vector2(transform.position.x + addToRayCastStart, 0), new Vector2(transform.position.x + addToRayCastEnd, 0));
//		if(hit.collider == false){

        	if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        	{
				
           		 transform.position += Vector3.right.normalized * movementSpeed * Time.deltaTime;
				//Debug.Log(hit.collider.name);

       		 }
	
        #endregion

        #region MoveUpwards
        // UPWARD MOVEMENT //
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("Moving Upwards...");
            transform.position += Vector3.up.normalized * movementSpeed * Time.deltaTime;
        }
        #endregion

        #region MoveBackwards
        // DOWNWARD MOVEMENT //
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("Moving Downwards...");
            transform.position += Vector3.down.normalized * movementSpeed * Time.deltaTime;
        }
        #endregion
}
    
	//}

	void rayCastCheck(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right);

		//RaycastHit2D (Vector2 (this.gameObject.transform.position), Vector2 (1, 0), 1 = Mathf.Infinity, 0.5f = -Mathf.Infinity, 1f = Mathf.Infinity);
		//Debug.DrawRay (RaycastHit2D (Vector2 (this.gameObject.transform.position), Vector2 (1, 0), 1 = Mathf.Infinity, 0.5f = -Mathf.Infinity, 1f = Mathf.Infinity));
	}

}
