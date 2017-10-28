using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour {

    
    public Transform replacementPlatform;

    public int waitForCrumble = 1;
    public int waitForReturn = 3;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Recognizes the Player");
            StartCoroutine(DestroyAndBuild());
        }
       
    }

    //coroutine used to hide, replace, and destroy the platform.
    IEnumerator DestroyAndBuild()
    {
        yield return new WaitForSeconds(waitForCrumble); //the player has three seconds to get off before the platform dissapears

        //hide this platform and make non-interactable
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        

        //wait to replace it
        yield return new WaitForSeconds(waitForReturn);

        //replace platform
        Instantiate(replacementPlatform);
        

        //destroy this platform
        Destroy(gameObject);
        StopCoroutine(DestroyAndBuild());

    }
}
