using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatScript : MonoBehaviour
{

    // Setting up for refrencing player and enemy objects
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public GameObject attackButton;
    public GameObject defenseButton;

    // Specifically calling them out
    private PlayerVars playerVars;
    private int checker = 1;

    int rndNum;

    // Use this for initialization
    void Start ()
    {
        // Linking them together.
        playerVars = playerGameObject.GetComponent<PlayerVars>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (checker == 0)
        {
            buttonDisabler();
        }
        else
        {
            buttonEnabler();
        } */
    }

    public void playerRound()
    {
        buttonDisabler();
        //enemyRound();
    }

    public void buttonDisabler()
    {
        attackButton.SetActive(false);
        defenseButton.SetActive(false);
    }

    public void buttonEnabler()
    {
        attackButton.SetActive(true);
        defenseButton.SetActive(true);
    }

    IEnumerator waitEnd()
    {
        yield return new WaitForSeconds(1);
        buttonEnabler();
    }





   /* public void enemyRound()
    {
        // Enemy attacks, reducing playerHP with enemyATT.

        // Accuracy check
        rndNum = Random.Range(1, 101);

        // If it hit, do the damages
        if (rndNum > playerVars.playerDEF)
        {
            playerVars.playerHealth.CurrentVal = playerVars.playerHealth.CurrentVal - enemyVars.enemyATT;
        }

        // If it didn't hit, say so then JEEZ.
        else
        {
        }


        //Checker for playerHP
        if (playerVars.playerHealth.CurrentVal <= 0)
        {
            Application.Quit();
        }
        StartCoroutine("waitEnd");
    } */
}
