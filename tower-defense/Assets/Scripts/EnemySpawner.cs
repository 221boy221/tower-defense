using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private Transform enemy;
    [SerializeField] private Transform enemy2;
    private float totalEnemies = 100;

	void Start () {
        SpawnEnemies();
	}

    void SpawnEnemies() {
        for (var i = 0; i < totalEnemies; i++) {
            switch (Random.Range(1,3)){
                case 1:
                    Instantiate(enemy, new Vector3(Random.Range(-4f, 4f), i * 2 + 10, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy2, new Vector3(Random.Range(-4f, 4f), i * 2 + 10, 0), Quaternion.identity);
                    break;
                default:
                    break;
            }
            
            
        }
    }
	
}
