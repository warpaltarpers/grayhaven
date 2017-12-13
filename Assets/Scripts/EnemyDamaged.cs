using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private void Update()
    {

        if (currentHealth <= 0)
            Destroy(this.gameObject);

    }

    //Melee Attack Damage
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerMeleeAttack"))
        {

            currentHealth -= 20;
            

        }
    }
}
