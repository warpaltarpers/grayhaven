using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ImageEffectsZone : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        
        Camera.main.GetComponent<Bloom>().enabled = true;

    }
    void OnTriggerExit2D()
    {

        Camera.main.GetComponent<Bloom>().enabled = false;

    }
}
