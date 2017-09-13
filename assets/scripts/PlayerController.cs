using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	public int playerHealth = 100;

	Animator anim;

	public bool isGrounded;

	//public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;


	void Start ()
	{ 
		// This allows for the sprites to change based on the code being run
		anim = GetComponent<Animator> ();

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

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update() 
	{
		if (Input.GetButtonDown ("Jump") && isGrounded) 
		{
			//anim.SetBool ("Ground", false);
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}

	// Creates a function that will automatically flip the animation when the player changes directions 
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
 

}