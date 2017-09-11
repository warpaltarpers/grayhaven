using UnityEngine;
using System.Collections;

public class BasicEnemy : MovingObject {

  public int playerDamage;
  public int enemyHealth;

  private Animator animator;
  private Transform target;

  protected override void Start ()
  {
    animator = GetComponent<Animator>();
    target = GameObject.FindGameObjectWithTag ("Player").transform;
    base.Start();
  }

  protected override void AttemptMove <T> (int xDir, int yDir)
  {
    base.AttemptMove <T> (xDir, yDir);
  }

  public void MoveEnemy()
  {
    int xDir = 0;
    int yDir = 0;

    if (Mathf.Abs (target.position.x = transform.position.x) < float.Epsilon)
      yDir = target.position.y > transform.position.y ? 1 : -1;
    else
      xDir = target.position.x > transform.position.x ? 1 : -1;

        AttemptMove<Player>(xDir, yDir);
  }

  protected override void OnCantMove <T> (T component)
  {
    Player hitPlayer = component as Player;

    hitPlayer.LoseHealth(playerDamage);
  }
}
