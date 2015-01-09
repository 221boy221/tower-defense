using UnityEngine;
using System.Collections;

    // Swan

public class SpawnScript : MonoBehaviour {

    public WaypointTest waypoints;
    public GameObject[] enemyTypes;
    public float interval = 3.0f;
    private int _currentEnemyIndex = -1;
    private float _timeLeft = 0.0f;

    GameObject[] enemyWaves;

    void Update() {

        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0.0f) {

            // enemy sequance
            _currentEnemyIndex++;
            if (_currentEnemyIndex >= enemyTypes.Length) _currentEnemyIndex = 0;

            Debug.Log("Spawn Enemy");

            GameObject g = (GameObject)Instantiate(enemyTypes[_currentEnemyIndex], transform.position, Quaternion.identity);
            g.GetComponent<Enemy>().waypoints = waypoints.wayPoints;

            _timeLeft = interval;
        }

    }
}
