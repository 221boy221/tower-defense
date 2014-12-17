using UnityEngine;
using System.Collections;

    // Swan

public class WaypointTest : MonoBehaviour {

    public float accelerate = 1.8f;
    public Transform[] wayPoints = new Transform[6];
    int currentWayPoint = 0;

    // Update is called once per frame
    void Update() {
        if (currentWayPoint == 20) {
            Destroy(this.gameObject);
        } else {
            walk();
        }
    }

    void walk() {
        Vector2 wayPointDirection = wayPoints[currentWayPoint].position - transform.position;
        float speedElement = Vector2.Dot(wayPointDirection.normalized, transform.forward);
        float speed = accelerate * speedElement;
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "wayPoint") {
            currentWayPoint++;
        }
    }
}
