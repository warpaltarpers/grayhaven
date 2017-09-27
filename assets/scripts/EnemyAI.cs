using UnityEngine;
using System.Collections;
using Pathfinding; // links to A* Pathfinding

// Locking it to the enemy objects
[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]
public class EnemyAI : MonoBehaviour {

    // What to chase
    public Transform target;

    // How many times each second it will update the path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    // The calculated path to the player
    public Path path;

    // AI speed per second
    public float speed = 300;
    public ForceMode2D fMode;
    public bool isGrounded;
    public float jumpForce = 700;

    //public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    [HideInInspector] // Makes sure pathIsEnded is public, but that it won't show up in the Inspector
    public bool pathIsEnded = false;

    // The max distance from an AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null) {
            Debug.LogError("No player found");
            return;
        }

        // Start a new path to the target position and return result to OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath() {
        if(target == null) {
            //TODO: Insert player search here.
        }

        // Start a new path to the target position and return result to OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p) {
        Debug.Log("We got a path. Did it have an error?" + p.error);

        // if there is no error, follow this path
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate() {
        if (target == null) {
            //TODO: Insert player search here.
        }

        //TODO: Always look at player?

        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count) {
            if (pathIsEnded)
                return;

            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        // Find direction to next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        // Move AI
        rb.AddForce(dir, fMode);

        if ((target.position.y > transform.position.y) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime);
        }

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }
    }
}
