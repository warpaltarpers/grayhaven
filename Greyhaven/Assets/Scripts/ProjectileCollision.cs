using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {

    //public GameController gameController;
    //public GameObject gameControllerObject;
    
        //setup for projectile
    public GameObject projectilePrefab;
    private System.Collections.Generic.List<GameObject> Projectiles = new System.Collections.Generic.List<GameObject>();
    private float projectileVelocity = 3;
    
    //private Collider2D other;

    // Use this for initialization
    void Start () {
        //gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        //gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() {
        // If fire 2 button is pressed, fire projectile
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(bullet);
        }

        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBullet = Projectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(1, 0) * Time.deltaTime * projectileVelocity);
                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
                }

            }
        }
        //Projectile script ends
    }

    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BasicEnemy")
        {
            Destroy(col.gameObject);
        }
    } */



}
