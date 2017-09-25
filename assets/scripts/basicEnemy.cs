using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {

    public int playerDamage;
    public int enemyHealth;
    public int moveSpeed;
    public PlayerController player;

    private Vector2 transformTemp;
    private Transform target;

    protected override void Start () {

        transformTemp = transform.position;
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        base.Start();
    }

    void Update() {

        transformTemp = transform.position;
        Vector2 targetPosition = target.transform.position;
    }

    public void MoveEnemy()  {

        if(player.position.x == ) {//enter enemy x position here

        }
    }

    
}
