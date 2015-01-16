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

    private int enemyCount;
    private float enemySpawnDelay = 0.0f;
    private float waveWait = 10.0f;
    private bool spawn = true;
    private bool spawnWave = false;
    private int maxEnemies = 10; 
    private int _waveCounter = 0;

    //void Start() {
    //    waveCountText = GetComponentInChildren<Text>();
    //    waveTimeText = GetComponentInChildren<Text>();
    //}

    void Update() {
        // Wave system
        waveWait -= Time.deltaTime;
        Mathf.Ceil(waveWait);
        waveTimeText.text = "Next wave in: " + waveWait;

        if (spawn) {
            if (waveWait <= 0) {
                spawnWave = true;
                waveWait = 60.0f;

                _waveCounter++;
                waveCountText.text = "Wave: " + _waveCounter;
            }

            if (spawnWave) {
                enemySpawnDelay += Time.deltaTime;

                if (enemySpawnDelay >= 1.0f) {
                    enemySpawnDelay = 0.0f;
                    SpawnEnemy();
                    enemyCount++;
                }
            }

            if (enemyCount >= maxEnemies) {
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
}
