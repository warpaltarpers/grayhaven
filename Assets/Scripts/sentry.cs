using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentry : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;

	public sentryAttack sentryAttackScript;


	public int currentHealth;
    public int maxHealth;


    public float distance;
    public float shootInterval;
    public float projectileSpeed = 100;
    public float projectileTimer;
    public float lookTimer;


    public bool playerOnRight = true;
    public bool lookingRight = true;
    public bool alternateLeftRightLook = false;

    public GameObject projectile;

    //target is the player character
    //need to drag player to this in inspector
    public Transform target;

    public Transform shootPointLeft;
    public Transform shootPointRight;
    public Transform shootPointBelow;





    private void Awake()
    {
        sentryAttackScript = gameObject.GetComponentInChildren<sentryAttack>();

    }

    private void Start()
    {
		
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;

    }

    private void Update()
    {
        //track which side the player is on
		if (target.transform.position.x > transform.position.x)
		{
			playerOnRight = true;
		}

		if (target.transform.position.x < transform.position.x)
		{
			playerOnRight = false;
		}


        //If bool alternateLeftRightLook is true 
        //use the lookDirection function to control which way the sentry is looking
        if(alternateLeftRightLook == true)
        {
            lookDirection();
        }

       

        //destroy sentry
		if (currentHealth <= 0)
		{

			Destroy(this.gameObject);

		}

            
    }


    //sentry switches what direction it looks if bool lookLeftRight is true in sentryAttack script
    //can add controls for looking animation here
    void lookDirection()
    {

        lookTimer += Time.deltaTime;

		// if player is sighted, the sprite will flip based on following the player
		//else, the lookDirection function used
		if (sentryAttackScript.playerSighted && playerOnRight)
		{
			mySpriteRenderer.flipX = false;

		}
		else if (sentryAttackScript.playerSighted && playerOnRight == false)
		{
			mySpriteRenderer.flipX = true;

		}
        else 
        {
			if (lookTimer >= 5)
			{
				if (mySpriteRenderer.flipX != true)
				{
					mySpriteRenderer.flipX = true;
					lookingRight = false;
				}
				else
				{
					mySpriteRenderer.flipX = false;
					lookingRight = true;
				}

				lookTimer = 0;
			}
        }
            
    }

    //attack function that is called in sentryAttack.cs
    public void Attack(bool attackingRight)
    {
        projectileTimer += Time.deltaTime;

        if(projectileTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

			GameObject projectileClone;
            projectileClone = Instantiate(projectile, shootPointBelow.transform.position, shootPointBelow.transform.rotation) as GameObject;
			projectileClone.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

			projectileTimer = 0;

			/*had code for sentry that was floor level and would fire from the left and right of its body.
			 * utilizing shootpoint left and shootpoint right.
			* Currently the sentry fires from one spot on its body (shootPointBelow).
			* 
		   if(!attackingRight)
		   {
			   GameObject projectileClone;
			   projectileClone = Instantiate(projectile, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
			   projectileClone.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

			   projectileTimer = 0;
		   }


		   if(attackingRight)
		   {
			   GameObject projectileClone;
			   projectileClone = Instantiate(projectile, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
			   projectileClone.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

			   projectileTimer = 0;
		   }
		   */

        }

    }


    public void EnemyTakeDamage(int damage)
	{
        currentHealth -= damage;

	}
}
