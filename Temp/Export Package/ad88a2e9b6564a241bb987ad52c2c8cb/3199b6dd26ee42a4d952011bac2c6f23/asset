using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVars : MonoBehaviour {

    // Setting up for refrencing player and enemy objects
    public GameObject enemyGameObject;
    // Specifically calling them out

    [SerializeField]
    public Stat playerHealth;

    // Use this for initialization
    private void Awake()
    {
        playerHealth.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerHealth.CurrentVal = playerHealth.CurrentVal - 10;
            print("boop");
        }
    }

    /*public void basicAttack()
    {
        int rndNum;
        // Player attacks with space, reducing enemyHP with playerATT.

        // Accuracy check
        rndNum = Random.Range(1, 101);

        // If it hit, do the damages
        if (rndNum > enemyVars.enemyDEF)
        {
            enemyVars.enemyHealth.CurrentVal = enemyVars.enemyHealth.CurrentVal - playerATT;
        }


    } */
}
