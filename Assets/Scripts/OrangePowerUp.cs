using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePowerUp : MonoBehaviour {

    // Variables

    // Projectile Variables
    private System.Collections.Generic.List<GameObject> Projectiles = new System.Collections.Generic.List<GameObject>();
    private Collider2D other;
    private float nextFire;
    public float powerEquipped = 1;
    public float projectileVelocity;
    //public float fireRate;
    public bool isBullet = false;
    public GameObject projectilePrefab;
    public Vector2 aim = new Vector2 (1, 0);

    //Invulnerability Variables
    public bool invuln = false;
   // public Material Mat_player;
   // public Material Mat_invuln;
    //public Renderer rend;

    // Object Variables
    public bool pickedUp;

    // A. Start
    // B. Update
    // C. Pickup Orange Powerup

    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // A. Start
    void Start() {

    // Starts the player without the orange powerup
        pickedUp = false;
    // Equips the red powerup to the player
        powerEquipped = 1;
        // Visual cue for invulnerability
        // rend = GetComponent<Renderer>();
        //rend.material = Mat_player;
        aim = new Vector2(1, 0);
    }

    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // B. Update
    void Update() {

        // 1. Picking up the orange power
        // 2. Power Switching
        // 3. Projectile
        // 4. Shield
        // 5. Bullet Controller

        //====================================================
        // 1. Picking up the orange power
        //====================================================

        if (pickedUp == true)
        {

        //====================================================
        // 2. Power Switching
        //====================================================
        // Power 1 = red
        // Power 2 = orange

        // If the red power is equipped and the switch button is pressed, equip the orange power
            if (Input.GetButtonDown("colorSwap"))
            {
                if (powerEquipped == 1)
                {
                    powerEquipped = 2;
        // If the red power is equipped and the switch button is pressed, equip the orange power
                }
                else if (powerEquipped == 2)
                {
                    powerEquipped = 1;
                }
            }

        //====================================================
        // 3. Projectile
        //====================================================

        // Only do projectiles if orange weapon is equipped
            if (powerEquipped == 2)
            {
                //float primaryAttack = Input.GetAxis("primaryAttack");
                //primaryAttack > 0
                    // If fire2 button is pressed, there is no bullet already, and the shield is not active: fire projectile
                    if (Input.GetButton("Fire1") && !isBullet && !invuln)
                {
                    // Create a bullet
                    isBullet = true;
                    GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                    // Makes sure the bullet doesn't change directions mid flight
                    
                    if (PlayerController.shootRight == true)
                    {
                        projectileVelocity = 16;
                    } else if (PlayerController.shootRight == false)
                    {
                        projectileVelocity = -16;
                    }  else
                    {
                        projectileVelocity = 16;
                    }
                    Projectiles.Add(bullet);

                    // Decrement energy
                   // GameObject.Find("Player").GetComponent<PlayerController>().playerEnergy -= 1;
                }

        //====================================================
        // 4. Shield
        //====================================================

                // Switches between projectile mode and shield mode
                if (Input.GetButtonDown("Fire2"))
                {
                    // If in projectile mode, switch to shield mode
                    if (invuln == false)
                    {
                        invuln = true;
                        //rend.material = Mat_invuln;
                    }
                    // If in shield mode, switch to projectile mode
                    else
                    {
                        invuln = false;
                        //rend.material = Mat_player;
                    }
                }
            }

        //====================================================
        // 5. Bullet Controller
        //====================================================

            // Governs the bullet as a projectile
            for (int i = 0; i < Projectiles.Count; i++)
            {
                GameObject goBullet = Projectiles[i];

                // Tells the bullet what to do if it exists
                if (goBullet != null)
                {
                    // If a bullet is created, fire it in direction "aim" at speed "projectileVelocity"
                    goBullet.transform.Translate(aim * Time.deltaTime * projectileVelocity);
                    Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);

                    // If the bullet leaves the screen, destroy it
                    if (bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0)
                    {
                        DestroyObject(goBullet);
                        Projectiles.Remove(goBullet);
                        isBullet = false;
                    }
                }
            }
        }
    }

    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // C. Pickup Orange Powerup

    // If the player collides with the orange powerup item, give the player the power and destroy the item
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OrangePower")
        {
            Debug.Log("I am deer");
            Destroy(other.gameObject);
            pickedUp = true;
        }
    }
}