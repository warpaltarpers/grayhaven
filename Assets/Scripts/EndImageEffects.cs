using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EndImageEffects : MonoBehaviour {


    public bool EndEffectsTriggered;
    public bool End;

    private float t = 0; // lerp control variable
    public float duration = 15; // duration in seconds
    public float startThresholdR;
    public float startThresholdG;
    public float startThresholdB;

    // Use this for initialization
    void Start()
    {
        startThresholdR = 225;
        startThresholdR = 192;
        startThresholdR = 174;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            //EndEffectsTriggered = true;
            //Camera.main.GetComponent<Bloom>().enabled = true;
            //Camera.main.GetComponent<SunShafts>().enabled = true;


        }
    }
    void OnTriggerEnter2D()
    {
        //if (other.transform.tag == "Player")
        //{
        // EndEffectsTriggered = true;
        Camera.main.GetComponent<Bloom>().enabled = true;
        Camera.main.GetComponent<SunShafts>().enabled = true;


        // }

    }
    // Update is called once per frame
    void Update()
    {



        if (EndEffectsTriggered && !End)
        {
            End = true;
            if (t < 1)
            {
                Camera.main.GetComponent<SunShafts>().sunThreshold.r = Mathf.Lerp(startThresholdR, 0, t);
                Camera.main.GetComponent<SunShafts>().sunThreshold.g = Mathf.Lerp(startThresholdG, 0, t);
                Camera.main.GetComponent<SunShafts>().sunThreshold.b = Mathf.Lerp(startThresholdB, 0, t);
                // while t below the end limit...
                // increment it at the desired rate every update:
                t += Time.deltaTime / duration;
            }
        }
    }


}
