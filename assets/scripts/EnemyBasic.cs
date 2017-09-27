using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{

    public GameController gameController;
    public GameObject gameControllerObject;
    public int enemyHealth = 100;
    public int moveSpeed = 5;

    private Collider2D other;

    // Use this for initialization
    void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void Update()
    {
 
        if (enemyHealth <= 0)        {
           
            gameController.UpdateEnemyCount();
            Destroy(this.gameObject);
            
        }
    }

    /*
     * Detect collisions
     * 
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
            enemyHealth -= 50;

    }
}