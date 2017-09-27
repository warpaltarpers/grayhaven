 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text enemyCountText;
    public Text winText;

    private int numOfEnemies;
    

	// Use this for initialization
	void Start () {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        setEnemyText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        /*
         * End the game if there are no enemies left
         */

    }

    /*
     * This is currently public... needs to be reworked.
     * 
     * Updates numOfEnemies whenever an enemy is destroyed
     * 
     */
    public void UpdateEnemyCount()    {
        numOfEnemies--;
        setEnemyText();
    }

    void setEnemyText()    {
        enemyCountText.text = "Enemies: " + numOfEnemies.ToString();
        if(numOfEnemies <= 0)   {
            winText.text = "You Win";
        }
    }
}
