using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretBehaviour : MonoBehaviour {
    
    [SerializeField]
    private GameObject bulletPrefab;
    private float nextFireTime = 1;
    private float fireRate = 0.2f;
    private List<GameObject> enemyList = new List<GameObject>();

	void Update () {
        // Remove nulls from the list
        for (int i = 0; i < enemyList.Count; i++) {
            if (enemyList[i] == null) {
                enemyList.Remove(null);
            }
        }

        // Look at enemy
        if (enemyList.Count > 0) {
            this.transform.LookAt(enemyList[0].gameObject.transform);
            // If able to shoot
            if (Time.time > nextFireTime) {
                ShootBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
	}

    void ShootBullet() {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    // When enemy is in range
    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Enemy") {
            // If list isn't empty
            if (enemyList.Count > 0) {
                // If current target's speed is less than the new target's speed, switch target.
                if (enemyList[0].GetComponent<EnemyBehaviour>().movementSpeed < target.GetComponent<EnemyBehaviour>().movementSpeed) {
                    enemyList.Add(enemyList[0]);
                    enemyList[0] = target.gameObject;
                } else {
                    enemyList.Add(target.gameObject);
                }
            } else {
                enemyList.Add(target.gameObject);
            }
        }
    }

    // When enemy is out of range
    void OnTriggerExit2D(Collider2D target) {
        if (target.gameObject.tag == "Enemy") {
            enemyList.Remove(target.gameObject);
        }
    }

}
