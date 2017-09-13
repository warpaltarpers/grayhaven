using UnityEngine;
using System.Collections;

public class BasicEnemy : MovingObject {

  public int playerDamage;
  public int enemyHealth;
  public GameObject player;

  private Vector3 transformTemp;
  private Animator animator;
  private Transform target;

  protected override void Start () {
	transformTemp = transform.position;
    animator = GetComponent<Animator>();
    target = GameObject.FindGameObjectWithTag ("Player").transform;
    base.Start();
  }

 void Update() {
	

	transformTemp = transform.position;
	Vector3 targetPosition = target.transform.position;

 }

  protected override void AttemptMove <T> (int xDir, int yDir) {
    base.AttemptMove <T> (xDir, yDir);
  }

  public void MoveEnemy()  {
		
    int xDir = 0;
    int yDir = 0;

		//Compare if objects are on the same x-axis
		//If so, move on the y-axis to the player
		//If not, move on x-axis to the player
	if (target.position.x == transformTemp.x)
      yDir = target.position.y > transform.position.y ? 1 : -1;
    else
      xDir = target.position.x > transform.position.x ? 1 : -1;


        AttemptMove<PlayerController>(xDir, yDir);
  }

    /**
     * LoseHealth is needed in PlayerController
     * If enemy can't move, check to see if colliding with player,
     * If colliding with player, deal damage to player
     * */
    protected override void OnCantMove <T> (T component) {
    PlayerController hitPlayer = component as PlayerController;

    hitPlayer.LoseHealth(playerDamage);
  }
}
