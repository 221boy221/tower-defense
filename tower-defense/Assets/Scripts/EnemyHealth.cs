using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float health = 100.0f;

    // When something comes in range
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Projectile") {
            float dmg = other.gameObject.GetComponent<BulletController>().damage;
            TakeDamage(dmg);
            Destroy(other.gameObject);
        }
    }

    // Take damage
    public void TakeDamage(float dmg) {
        health -= dmg;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
