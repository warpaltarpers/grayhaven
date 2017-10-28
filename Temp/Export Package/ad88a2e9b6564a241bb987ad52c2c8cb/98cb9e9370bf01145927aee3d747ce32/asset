using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformThreat : MonoBehaviour {

    //is the superheating/whatever threat turned on?
    public bool threatIsReal;


	void Start () {

      //starts the coruotine for alternating 
        StartCoroutine(OscilateBetweenThreatAndNot());
    }
	
    //Once the player hits the surface it will check to see if threat is on
        //Will need to see if this is redundant with the Stay one going as well
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Recognizes the Player");
            
            //if the threat is on at the moment of collision this code will link up with the health pf player to do harm
            if(threatIsReal)
            {
                Debug.Log("Player should have hot feet right about now");
            }
        }

    }

    //if the player remains on platform, it will continue to do harm
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Recognizes the Player");
            if (threatIsReal)
            {
                Debug.Log("Player should have hot feet right about now");
            }
        }

    }

    IEnumerator OscilateBetweenThreatAndNot()
    {
        
        //forces the coroutine to loop while true is true (so forever)
        while (true)
        {
            //red and white are visual cues for player. *****Will need some way of animating/will need work*****
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //boolean for threat equals true. Player can be harmed
            threatIsReal = true;
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //boolean for threat equals false. Player can nolonger be harmed
            threatIsReal = false;
            yield return new WaitForSeconds(2);
        }
      
        

        //the problem is that lerping wont work insode a coroutine

        //lerp the color
        //if the color = color.red
        //turn on danger 
        //wait a few seconds
        //turn off danger
        //lerp the color back 
        //start coroutine 



    }
}
