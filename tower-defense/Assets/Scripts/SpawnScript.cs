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

    private Player _player;

    private float _enemySpawnTime   = 0.0f;
    private float _enemySpawnDelay  = 2.0f;
    private float _waveWait         = 20.0f;
    private bool _spawnWave         = false;
    private int _maxArmorEnemies    = 10;
    private int _maxEnemies         = 10;
    private int _waveCounter        = 0;
    private int _enemyCount;

    void Awake() {
        _player = GameObject.FindGameObjectWithTag("GameController").GetComponent<Player>();
    }

    void Update() {
        // Wave system
        _waveWait -= Time.deltaTime;
        waveTimeText.text = "Next wave in: " + Mathf.RoundToInt(_waveWait);

        if (_waveWait <= 0) {
        // Wave Start (enable the enemies to spawn)
            _spawnWave = true;
            // Reset values
            _waveWait = 90.0f;
            _maxArmorEnemies = 0;
            // Play startwave sound
            _player.Source.PlayOneShot(_player.NextWaveAudio, 2f);
            // Decrease enemySpawnDelay
            if (_enemySpawnDelay >= 0.2f) {
                _enemySpawnDelay -= 0.1f;
            }
            // Set the wave text to the corresponding wave
            _waveCounter++;
            waveCountText.text = "Wave: " + _waveCounter;
        }

        if (_spawnWave) {
            // Spawn every 1 second
            _enemySpawnTime += Time.deltaTime;
            if (_enemySpawnTime >= _enemySpawnDelay) {
                _enemySpawnTime = 0.0f;
                _enemyCount++;
                SpawnEnemy();
            }
        }

        if (_enemyCount >= (_maxEnemies * _waveCounter) / 2) {
            _spawnWave = false;
            _enemyCount = 0;
        }

    }
    
    void SpawnEnemy() {
        Vector3 spawnPostition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject g;

        // Check the wave, when it's on wave 10, start spawning the rest of the enemies as well.
        if (_waveCounter >= 10 && _maxArmorEnemies < 1) {
            g = (GameObject)Instantiate(enemyTypes[enemyTypes.Length - 1], spawnPostition, spawnRotation);
            _maxArmorEnemies += 1;
            Debug.Log("Spawn Armor: " + _maxArmorEnemies);
        } else {
            g = (GameObject)Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length - 1)], spawnPostition, spawnRotation);
            Debug.Log("Spawn normal: " + g);
        }
        Debug.Log("Test");
        g.GetComponent<Enemy>().waypoints = waypoints.wayPoints;
    }
    
    // For the ingame button to skip timer
    public void NextWave() {
        _waveWait = 0.0f;
    }
}
