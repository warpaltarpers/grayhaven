using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                /* I think it would be useful to have a takeDamage function in the playerController
                 * too call here like takeDamage(5);
                 *
                 */
                if (!OrangePowerUp.invuln)
                {
                    col.GetComponent<HeartSystem>().TakeDamage(-2);
                }
            }


        }

    }

}
