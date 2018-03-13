using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Player Variables")]
    public float movementSpeed;

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
            Debug.Log("Moving Left...");
            transform.position += Vector3.left.normalized * movementSpeed * Time.deltaTime;
        }
        #endregion

        #region MoveRight
        // RIGHT MOVEMENT //
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right...");
            transform.position += Vector3.right.normalized * movementSpeed * Time.deltaTime;
        }
        #endregion

        #region MoveUpwards
        // UPWARD MOVEMENT //
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving Upwards...");
            transform.position += Vector3.forward.normalized * movementSpeed * Time.deltaTime ;
        }
        #endregion

        #region MoveBackwards
        // DOWNWARD MOVEMENT //
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving Downwards...");
            transform.position += Vector3.back.normalized * movementSpeed * Time.deltaTime;
        }
        #endregion

    }
}
