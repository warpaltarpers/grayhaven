using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    // This is for checking the fill amount of the bar; how much red/orange goo is in it, as a decimal value out of 1.
    private float fillAmount;

    [SerializeField]
    private Image content; // the image used as an energy bar

    //[SerializeField] commented out this and all things relating to having a text that tells you stuff 
    //private Text valueText; 

    [SerializeField]
    private float lerpSpeed; // how fast it trickles from one value to the next.

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            // commented out, but for adding in text that will tell how much there is
            //string[] tmp = valueText.text.Split(':');
            //valueText.text = tmp[0] + ": " + value;
            fillAmount = Map(value,0,MaxValue, 0,1);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
            // If there needs to be a change in the level of the fillamount, make it smooth and sexy
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
        
    }

    // This is overly complicated code that basically inputs health values and outputs them in a way the energy bar likes.
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(80-0)*(1 - 0)/(100-0)+0//
    }
}
