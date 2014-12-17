using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float health = 100.0f;
    public float damageReduction;

    // Take damage
    public void TakeDamage(float dmg) {

        dmg -= damageReduction;
        if (dmg < 0) dmg = 0;

        health -= dmg;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
