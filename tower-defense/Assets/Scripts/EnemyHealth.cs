using UnityEngine;
using System.Collections;

// Boy

public class EnemyHealth : MonoBehaviour {

    public float health = 100.0f;

    // Take damage
    public void TakeDamage(float dmg) {
        
        health -= dmg;
        
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
