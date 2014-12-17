using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Vector3 _velocity;
    private Transform destination;
    private float damage = 0.0f;
    private float speed = 2f;
    private float collisionDistance = 1.0f;
    private float arch = 2.5f;

    void Start() {
        _velocity = new Vector3(0, arch, 0);                                                                                                                
    }

    void Update() {
        // Destroy bullet if destination does not exist anymore
        if (destination == null) {
            Destroy(gameObject);
            return;
        }

        // Calculate step to target
        Vector3 offset = destination.position - transform.position;
        offset.Normalize();
        offset = offset * speed;
        _velocity = _velocity + offset;

        // Fly towards the destination
        transform.position = transform.position + (_velocity * Time.deltaTime);

        // When reached
        if (Vector3.Distance(transform.position, destination.position) < collisionDistance) {
            EnemyHealth enemy = destination.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    public void setDamage(float dmg) {
        damage = dmg;
    }

    public void setDestination(Transform target) {
        destination = target;
    }

}
