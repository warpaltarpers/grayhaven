using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 10f;
	public int playerHealth = 100;
    public GameObject meleeAttack;
    public bool isGrounded;
    public float jumpForce = 700;

    public float moveForward;

    public float swordLength;
    public GameObject meleeRay;
    public GameObject enemyBasic;
    
    public AudioClip dmg;

    //Flashing Damage
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private bool isDamaged;
    public static bool isPaused; //necessary for the pause menu

    Camera mainCamera;

    public float meleeDuration = 2.0f;



    Animator anim;
    bool facingRight = true;
    bool jumping;

	//public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

    private float attackDuration = 0.0f;

    private Collider2D other;
    private Vector2 meleeStrike;

    public Vector3 checkPointPos;


    void Start ()
	{ 
		// This allows for the sprites to change based on the code being run
		anim = GetComponent<Animator> ();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Checkpoint")
        {
            checkPointPos = other.transform.position;
        }
    }

	void FixedUpdate ()
	{
        // This constantly checks whether or not the player is touching the ground
        //grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);

        //track vertical velocity
        // Tells the animation how fast the player is moving up or down when jumping or falling
        anim.SetFloat("vertical", gameObject.GetComponent<Rigidbody2D>().velocity.y);

		// Gets input from the keyboard and reads how much the player is moving
		float move = Input.GetAxis ("Horizontal");

        moveForward = Input.GetAxis("Horizontal");
        float moveBackward = Input.GetAxis("Horizontal");
        anim.SetFloat("moveForward", moveForward);
        anim.SetFloat("moveBackward", moveBackward);

		// Controls the movement animation
		//anim.SetFloat("Speed", Mathf.Abs(move));

		// Creates the movement based on which direction the player intends to head
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


        /*
        //Left to Right
        if (Input.mousePosition.x > mainCamera.WorldToScreenPoint(transform.position).x && !facingRight)
        {
            Flip();
            meleeStrike = Vector2.right;
        }

        //Right to Left
        else if (Input.mousePosition.x < mainCamera.WorldToScreenPoint(transform.position).x && facingRight)
        {
            Flip();
            meleeStrike = Vector2.left;
        } 
        */

	}

	void Update() 
	{
        RaycastHit2D hit;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //anim.SetBool ("Ground", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            anim.SetTrigger("jump");
            jumping = true;
        }

        if (jumping == true && isGrounded)
        {
            anim.SetTrigger("landed");
            jumping = false;
        }


        if (moveForward > 0 && !facingRight)
        {
            Flip();

        }
        else if (moveForward < 0 && facingRight)
        {
            Flip();
        }

        /* if (moveForward != 0 && jumping == false)
        {

            AkSoundEngine.PostEvent("PLR_Footsteps", gameObject);

        }
        */

        /*
         * If fire button is pressed, activate meleeAttack game object for X seconds (determined by meleeDuration)
         * RT is a trigger has value between -1.0f and 1.0f. Snap setting in Input manager gives it value of 0 or 1.
         * If value is greater than 0, then attack
         * 
         */
        float primaryAttack = Input.GetAxis("primaryAttack");
        if (primaryAttack > 0)
        {
            anim.SetTrigger("rayAttack");
            meleeAttack.SetActive(true);
            attackDuration = Time.time + meleeDuration;

            /*
            Debug.DrawRay(meleeRay.transform.position, meleeStrike, Color.green, swordLength);
            hit = Physics2D.Raycast(meleeRay.transform.position, meleeStrike, swordLength);
            if (hit != null && hit.collider != null && hit.collider.tag == "Enemy")
            {
                enemyBasic = hit.collider.gameObject;
                //enemy = enemyBasic.GetComponent<EnemyBasic>();
                //enemy.TakeDamage();
            }
            */

        }

        if(Input.GetKeyDown("1")){
            anim.SetTrigger("rayAttack");
        }
                  
        if(meleeAttack.activeInHierarchy && Time.time > attackDuration)
        {
            meleeAttack.SetActive(false);
        }

        if (isDamaged)
        {
            damageImage.color = flashColour;
            //AudioSource.PlayClipAtPoint(dmg, transform.position, 3.0f);
            //AkSoundEngine.PostEvent("LVL_Player_Dmg", enemyBasic);

        }
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        isDamaged = false;




		//flip by using right joystick
		var dir = Mathf.Sign(Input.GetAxis("lookDirection"));

		if ((Input.GetAxis("lookDirection") > 0.1f && this.transform.localScale.x != 1) || (Input.GetAxis("lookDirection") < -0.1f && this.transform.localScale.x != -1))
		{

			Flip();
		}


	}

	

	// Creates a function that will automatically flip the animation when the player changes directions 
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Attack") && isPaused == false)        {

       
            gameObject.GetComponent<HeartSystem>().TakeDamage(-2);
            isDamaged = true;
 
        }
    }

}