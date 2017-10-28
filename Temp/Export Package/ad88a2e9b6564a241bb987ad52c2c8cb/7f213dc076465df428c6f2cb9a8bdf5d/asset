using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour {

    
    GameObject tempObject;
    public PlayerController refPlayerController;

    private void Start()
    {
        tempObject = GameObject.FindGameObjectWithTag("Player");
    }

    /*
     * This whole class is useful for all game objects, but currently set for the player only.
     * 
     * Parameters: Null
     * Returns: Null, but sets a public bool on PlayerController to true while player is on ground
     */
    void OnCollisionEnter2D(Collision2D other)    {

        refPlayerController = tempObject.GetComponent<PlayerController>();

        if (other.gameObject.CompareTag("Player"))        {

            refPlayerController.isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)    {

        refPlayerController = tempObject.GetComponent<PlayerController>();

        if (other.gameObject.CompareTag("Player"))        {
            refPlayerController.isGrounded = true;
        }
    }

   void OnCollisionExit2D(Collision2D other)    {

        refPlayerController = tempObject.GetComponent<PlayerController>();

        if (other.gameObject.CompareTag("Player"))      {

            if (refPlayerController)
                refPlayerController.isGrounded = false;
        }
    }

}
