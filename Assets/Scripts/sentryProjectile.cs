using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryProjectile : MonoBehaviour {

    private bool shootThrough;

    private void OnTriggerEnter2D(Collider2D col)
    {
        shootThrough = false;

        if(col.isTrigger != true)
        {
            if(col.CompareTag("Player"))
            {
                /* I think it would be useful to have a takeDamage function in the playerController
                 * too call here like takeDamage(5);
                 *
                 */
                col.GetComponent<HeartSystem>().TakeDamage(-1);
            }



            if(col.CompareTag("Platform") ||col.CompareTag("Enemy") )
            {
                shootThrough = true;
            }

            if (shootThrough == false)
            {
                Destroy(gameObject);
            }

        }

    }
}
