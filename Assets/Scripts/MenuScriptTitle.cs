using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScriptTitle : MonoBehaviour
{
    private int checker = 0; // acting as lightswitch for pause menu
    public GameObject pauseButton;
    public GameObject gameOverButton;
    public GameObject quitButton;
    public GameObject quitButton2;
    public GameObject gameOverText;
    public GameObject healthChecker; // for checking to see if need to gameover
    private HeartSystem heartSystem;  // getting heart system code

    public void ChangeScene(string sceneName) // Get an input from button thats the scene name, change to that scene.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() // Get an input from button thats the scene name, change to that scene.
    {
        Application.Quit();
    }

    private void Awake()
    {
        // Set all these UI elements to not be visible or interactible.
        pauseButton.SetActive(false);
        quitButton.SetActive(false);
        quitButton2.SetActive(false);
        gameOverButton.SetActive(false);
        gameOverText.SetActive(false);
        heartSystem = healthChecker.GetComponent<HeartSystem>(); // linking them together so I can refrence that stuff
    }


    private void Update()
    {

        // pause menu code (check PauseGameObject for stuff if you cant find it on the button)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (checker == 0)
            {
                
                PatrolEnemyAI.isPaused = true;
                PlayerController.isPaused = true;
                sentryAttack.isPaused = true;
                Time.timeScale = 0;
                checker = 1;
                pauseButton.SetActive (true);
                quitButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                checker = 0;
                pauseButton.SetActive(false);
                quitButton.SetActive(false);
                PatrolEnemyAI.isPaused = false;
                PlayerController.isPaused = false;
                sentryAttack.isPaused = false;
            }
         
        }


        // Game over code (also set up in the same PauseGameObject as pause menu)
            if (heartSystem.curHealth == 0)
            {
                Time.timeScale = 0; 
                gameOverButton.SetActive(true);
                quitButton.SetActive(true);
                gameOverText.SetActive(true);
            }
    }
    

}