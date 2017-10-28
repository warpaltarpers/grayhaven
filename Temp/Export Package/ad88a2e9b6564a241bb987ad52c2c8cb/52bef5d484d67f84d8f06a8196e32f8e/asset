using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform1 : MonoBehaviour {

    public GameObject Platform; //the object you want moved

    public float movementSpeed; //rate the object travels from point to point

    public Transform currentDestination; //keeping track of current desired destination in array
    public Transform[] Destinations; //array for as many destinations to move from you want (makes this more versitile)

    public int destinationSelection; //the selected destination out of the array to which the object shall travel next

    void Start()
    {
        //set the current destination to the first destination in the array
        currentDestination = Destinations[destinationSelection];
    }

    void Update()
    {
        //every update move the platform towards the destination
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentDestination.position, Time.deltaTime * movementSpeed);

        //if reaches destination adjusts to move towards the next
        if (Platform.transform.position == currentDestination.position)
        {
            destinationSelection++;

            //if out of destnations in the array will return to destination 0 and repeat the process
            if (destinationSelection == Destinations.Length)
            {
                destinationSelection = 0;
            }

            currentDestination = Destinations[destinationSelection];
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //if player lands on the platform, the player is the child of the platform (thus moving the player with it)
        if (other.transform.tag == "Player")
        {
            other.transform.parent = Platform.transform;
        }
    }

    
    void OnCollisionExit2D(Collision2D other)
    {
        //if the player leaves the platform, the player is nolonger childed 
        if (other.transform.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
