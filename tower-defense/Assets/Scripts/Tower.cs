using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    public BulletController bulletPrefab = null;
    public float interval = 2.0f;
    public float range = 10.0f;
    public float rotationSpeed = 2.0f;
    public int buildPrice = 1;
    private float timeLeft = 0.0f;

    EnemyBehaviour findClosestTarget() {
        EnemyBehaviour closest = null;
        Vector3 pos = transform.position;

        EnemyBehaviour[] enemies = (EnemyBehaviour[])FindObjectsOfType(typeof(EnemyBehaviour));

        if (enemies != null) {
            if (enemies.Length > 0) {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i) {
                    float current = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);

                    if (current < old) {
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f) {
            // Find the closest target (if any)
            EnemyBehaviour target = findClosestTarget();
            if (target != null) {
                if (Vector3.Distance(transform.position, target.transform.position) <= range) {
                    // spawn bullet
                    GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
                    // get access to bullet component
                    BulletController b = g.GetComponent<BulletController>();
                    // set destination        
                    b.setDestination(target.transform);
                    // reset time
                    timeLeft = interval;
                }
            }
        }

        // Rotate the tower
        //Vector3 rot = transform.eulerAngles;
        //transform.rotation = Quaternion.Euler(rot.x, rot.y + Time.deltaTime * rotationSpeed, rot.z);
    }

}
