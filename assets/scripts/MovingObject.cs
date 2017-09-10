using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

  public float moveTime = 0.1f;
  public LayerMask blockingLayer; //Change 'blockingLayer' to whatever layer will be used to check collision

  private BoxCollider2D boxCollider;
  private Rigidbody2D rb2D;
  private float inverseMoveTime;

  // Use this for initialization
  protected virtual void Start () {
    boxCollider = GetComponent<BoxCollider2D>();
    rb2D = GetComponent<Rigidbody2D>();
    inverseMoveTime = 1f / moveTime;
  }

  // Update is called once per frame
  void Update {

  }
}
