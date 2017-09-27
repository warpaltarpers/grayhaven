using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 10f;
	public int playerHealth = 100;
    public GameObject meleeAttack;
    public bool isGrounded;
    public float jumpForce = 700;
    Camera mainCamera;

    public float meleeDuration = 2.0f;

    //setup for projectile
    public GameObject projectilePrefab;
    private System.Collections.Generic.List<GameObject> Projectiles = new System.Collections.Generic.List<GameObject>();
    private float projectileVelocity = 3;

    Animator anim;
    bool facingRight = true;

	//public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

    private float attackDuration = 0.0f;


	void Start ()
	{ 
		// This allows for the sprites to change based on the code being run
		anim = GetComponent<Animator> ();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	void FixedUpdate ()
	{
		// This constantly checks whether or not the player is touching the ground
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//anim.SetBool ("Ground", grounded);

		// Tells the animation how fast the player is moving up or down when jumping or falling
		//anim.SetFloat ("vSpeed", gameObject.GetComponent<Rigidbody2D> ().velocity.y);

		// Gets input from the keyboard and reads how much the player is moving
		float move = Input.GetAxis ("Horizontal");

		// Controls the movement animation
		//anim.SetFloat("Speed", Mathf.Abs(move));

		// Creates the movement based on which direction the player intends to head
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


        
        //Left to Right
		if (Input.mousePosition.x > mainCamera.WorldToScreenPoint(transform.position).x && !facingRight)
			Flip ();

        //Right to Left
		else if (Input.mousePosition.x < mainCamera.WorldToScreenPoint(transform.position).x && facingRight)
			Flip ();
	}

	void Update() 
	{
		if (Input.GetButtonDown ("Jump") && isGrounded) 
		{
			//anim.SetBool ("Ground", false);
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}

        /*
         * If fire button is pressed, activate meleeAttack game object for X seconds (determined by meleeDuration)
         * 
         */
        if (Input.GetButtonDown("Fire1"))   {
            meleeAttack.SetActive(true);
            attackDuration = Time.time + meleeDuration;
        }      
        if(meleeAttack.activeInHierarchy && Time.time > attackDuration)
        {
            meleeAttack.SetActive(false);
        }

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



	// Creates a function that will automatically flip the animation when the player changes directions 
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
 

}