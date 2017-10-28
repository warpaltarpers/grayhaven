using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {
    //Damage stuff
    public GameObject enemyBasic;
    public EnemyBasic enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //goBullet.transform.Translate(GameObject.Find("Player").GetComponent<PlayerController>().projectileDirection * Time.deltaTime * projectileVelocity);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I am Here");



        if (other.gameObject.tag == "Enemy")
        {


            //enemyBasic = other.GetComponent<Collider>().gameObject;
            //enemy = enemyBasic.GetComponent<EnemyBasic>();
            //enemy.TakeDamage();

            
        }

        if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<OrangePowerUp>().isBullet = false;
        }

        


    }
}
