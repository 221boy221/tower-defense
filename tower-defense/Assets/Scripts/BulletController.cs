using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
    public int damage = 1;
    Transform destination;
    private Vector3 velocity;
    public float collisionDistance = 1f;
    public float arch;

    void Start() {
        velocity = new Vector3(0, arch, 0);
    }

    void Update() {
        // Destroy bullet if destination does not exist anymore
        if (destination == null) {
            Destroy(gameObject);
            return;
        }

        //float stepSize = Time.deltaTime * speed;

        // Calculate step to target
        Vector3 offset = destination.position - transform.position;
        offset.Normalize();
        offset = offset * speed;
        velocity = velocity + offset;

        // Fly towards the destination
        transform.position = transform.position + (velocity * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, destination.position, stepSize);

        // When reached
        if (Vector3.Distance(transform.position, destination.position) < collisionDistance) {
            EnemyHealth enemy = destination.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
        //if (transform.position.Equals(destination.position)) {
        //    // Deal damage

        //}
    }

    public void setDestination(Transform target) {
        destination = target;
    }

}
