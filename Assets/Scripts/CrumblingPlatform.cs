using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour {

    public GameObject[] children;

    public Transform replacementPlatform;

    public int waitForCrumble = 1;
    public int waitForReturn = 3;

    void Start()
    {
        //setting the sprites = to true
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        for (int i = 0; i < children.Length; i++)
        {
            //children[i].GetComponent<SpriteRenderer>().enabled = true;
            children[i].SetActive(true);
        }
        //enabling the boxcollider of this singular platform
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
        Debug.Log("waited to crumble");
        //hide this platform and make non-interactable
        //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        for (int i = 0; i < children.Length; i++)
        {
            //children[i].GetComponent<SpriteRenderer>().enabled = false;
            children[i].SetActive(false);
        }
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        

        //wait to replace it
        yield return new WaitForSeconds(waitForReturn);
        Debug.Log("waited to return");
        Debug.Log("before replacement");
        //replace platform
        //Instantiate(replacementPlatform);
        for (int i = 0; i < children.Length; i++)
        {
            
            children[i].SetActive(true);
        }
        //this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("after replacement");

        //destroy this platform
        //Destroy(gameObject);
        StopCoroutine(DestroyAndBuild());

    }
}
