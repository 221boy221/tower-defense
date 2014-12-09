using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed = 10.0f;
    public int damage = 1;
    Transform destination;

    void Update() {
        // Destroy bullet if destination does not exist anymore
        if (destination == null) {
            Destroy(gameObject);
            return;
        }
        
        float stepSize = Time.deltaTime * speed;

        // Fly towards the destination
        transform.position = Vector3.MoveTowards(transform.position, destination.position, stepSize);

        // When reached
        if (transform.position.Equals(destination.position)) {
            // Deal damage
            EnemyHealth enemy = destination.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    public void setDestination(Transform target) {
        destination = target;
    }

}
