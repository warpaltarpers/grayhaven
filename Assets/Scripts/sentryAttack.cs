using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * This script goes on the attackRange triggers for the sentry
 * 
*/


public class sentryAttack : MonoBehaviour {

    public sentry sentry;

    public static bool isPaused;

    //bool used if sentry triggers are on the left and right and not below. 
    //There are triggers not being used that can be used if the sentry needs to shoot left and right
    public bool isLeft = false;

    //bool to determine if the sentry has sighted the player
    public bool playerSighted = false;

  

    void Awake()
    {
        sentry = gameObject.GetComponentInParent<sentry>();

    }

    void OnTriggerStay2D(Collider2D col)
    {
                                  
        if(col.CompareTag("Player"))
        {
            //bool in sentry script to make sentry only shoot player if the sentry is looking left/right and
            //the player is on the left/right
            //If this is false, the sentry will fire when the player enters the trigger on either side
            if (sentry.alternateLeftRightLook == false)
            {
                playerSighted = true;
            }
            else
            {
                //check in trigger on left and sentry looking left
                if (sentry.playerOnRight == false && sentry.lookingRight == false)
                {
                    playerSighted = true;


                }
                //check in trigger and sentry looking right
                else if (sentry.playerOnRight == true && sentry.lookingRight == true)
                {
                    playerSighted = true;

                }
                else
                {

                }


            }

            //if player is in the trigger and the sentry is looking that direction
            //attack
            if (playerSighted == true && isPaused == false)
            {
                sentry.Attack(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
           playerSighted = false; 
        }

    }
}
