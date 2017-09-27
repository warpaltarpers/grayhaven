using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    public GameController gameController;
    public GameObject gameControllerObject;

    private Collider2D other;

    // Use this for initialization
    void Start () {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() { }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BasicEnemy")
        {
            Destroy(col.gameObject);
        }
    }



}
