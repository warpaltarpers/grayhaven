using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnergyBarScript : MonoBehaviour
{

    // THIS IS ONLY FOR THE ENERGY BAR TO POP UP AND GO AWAY, EVERYTHING ELSE IS IN OTHER STUFF
    private int checker = 0;
    public GameObject abilityWheel;


    void Start ()
    {
		abilityWheel.SetActive(false);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (checker == 0)
            {
                Time.timeScale = .10F;
                checker = 1;
                abilityWheel.SetActive(true);
                print("Ability wheel");
            }
            else
            {
                Time.timeScale = 1;
                checker = 0;
                abilityWheel.SetActive(false);
            }

        }
    }
}
