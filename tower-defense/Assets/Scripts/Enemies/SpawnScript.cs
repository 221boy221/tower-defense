using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Swan

public class SpawnScript : MonoBehaviour {

    public WaypointTest waypoints;
    public GameObject[] enemyTypes = new GameObject[0];
    public Vector3 spawnValues;
    public Text waveCountText;
    public Text waveTimeText;

    private float enemySpawnTime    = 0.0f;
    private float enemySpawnDelay   = 2.0f;
    private float waveWait          = 10.0f;
    private bool spawn              = true;
    private bool spawnWave          = false;
    private int maxEnemies          = 10; 
    private int _waveCounter        = 0;
    private int enemyCount;

    void Update() {
        // Wave system
        waveWait -= Time.deltaTime;
        waveTimeText.text = "Next wave in: " + Mathf.RoundToInt(waveWait);

        if (spawn) {
            if (waveWait <= 0) {
                // Wave Start (enable the enemies to spawn)
                spawnWave = true;
                // Reset countdown
                waveWait = 60.0f;
                // Decrease enemySpawnDelay
                if (enemySpawnDelay >= 0.2f) {
                    enemySpawnDelay -= 0.1f;
                }
                // Set the wave text to the corresponding wave
                _waveCounter++;
                waveCountText.text = "Wave: " + _waveCounter;
            }

            if (spawnWave) {
                // Spawn every 1 second
                enemySpawnTime += Time.deltaTime;
                if (enemySpawnTime >= enemySpawnDelay) {
                    enemySpawnTime = 0.0f;
                    enemyCount++;
                    SpawnEnemy();
                }
            }

            if (enemyCount >= (maxEnemies * _waveCounter) / 2) {
                spawnWave = false;
                enemyCount = 0;
            }
            
        }
    }
    
    void SpawnEnemy() {
        Vector3 spawnPostition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject g = (GameObject)Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPostition, spawnRotation);
        g.GetComponent<Enemy>().waypoints = waypoints.wayPoints;
    }
    
    // for the ingame button to skip timer
    public void NextWave() {
        waveWait = 0.0f;
    }
}
