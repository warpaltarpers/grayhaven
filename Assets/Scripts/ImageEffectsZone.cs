using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ImageEffectsZone : MonoBehaviour {

    public Transform player;

    public GameObject playerCamera;

   /* void OnTriggerEnter2D()
    {
        
        //Camera.main.GetComponent<Bloom>().enabled = true;

    }
    void OnTriggerExit2D()
    {

       // Camera.main.GetComponent<Bloom>().enabled = false;

    }*/

    void Update()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.position, transform.position);
            //print("Distance to player: " + dist);

            if (dist <= 15 && dist >= 1)
            {
                playerCamera.GetComponent<Bloom>().bloomIntensity = 2 / (dist);
            }
            if (dist > 15)
            {
                playerCamera.GetComponent<Bloom>().bloomIntensity = 0;
            }
        }
    }
}
