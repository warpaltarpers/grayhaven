using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

  public float moveTime = 0.1f;
  public LayerMask blockingLayer; //Change 'blockingLayer' to whatever layer will be used to check collision

  private BoxCollider2D boxCollider;
  private Rigidbody2D rb2D;
  private float inverseMoveTime;

  // Use this for initialization
  protected virtual void Start ()
  {
    boxCollider = GetComponent<BoxCollider2D>();
    rb2D = GetComponent<Rigidbody2D>();
    inverseMoveTime = 1f / moveTime;
  }

  protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
  {
    Vector2 start = transform.position;
    Vector2 end = start + new Vector2 (xDir, yDir);

    boxCollider.enabled = false;
    hit = Physics2D.Linecast (start, end, blockingLayer);
    boxCollider.enabled = true;

    if (hit.transform == null)
    {
      StartCoroutine(SmoothMovement (end));
    }
  }

  protected IEnumerator SmoothMovement (Vector3 end)
  {
    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
    while (sqrRemainingDistance > float.Epsilon)
    {
      Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
      rb2D.MovePosition(newPosition);
      sqrRemainingDistance = transform.position - end).sqrMagnitude;
      yield return null; // Waits for a frame before reevaluating condition of loop
    }
  }

  protected abstract void OnCantMove <T> (T component)
    where T : Component;
}
