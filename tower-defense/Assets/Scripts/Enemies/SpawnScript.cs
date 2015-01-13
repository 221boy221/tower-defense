using UnityEngine;
using System.Collections;

    // Swan

public class SpawnScript : MonoBehaviour {

    public WaypointTest waypoints;
    //public GameObject[] enemyTypes;
    //[HideInInspector]
    //public float interval = 10.0f;
    //private int _currentEnemyIndex = -1;
    //private float _timeLeft = 5.0f;
    //private int _waveCounter = 0;

    public GameObject[] enemyTypes = new GameObject[0];
    public Vector3 spawnValues;
    public int EnemyCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                Vector3 spawnPostition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject g = (GameObject)Instantiate(enemyTypes[Random.Range(0, 5)], spawnPostition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                g.GetComponent<Enemy>().waypoints = waypoints.wayPoints;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    //GameObject[] enemyWaves;

    //void Update() {
    //    _timeLeft -= Time.deltaTime;
    //    if (_timeLeft <= 0.0f)
    //    {

    //        if (_waveCounter >= 5)
    //        {
    //            _waveCounter = 0;
    //        }
    //        else
    //        {
    //            _waveCounter++;
    //        }

    //        // enemy sequance

    //        Debug.Log("Enemy Spawned");

    //        for (int i = 0; i <= 10; i++)
    //        {
    //            StartCoroutine(EnemySpawn(enemyTypes[_waveCounter], transform.position, Quaternion.identity,1f * i ));
    //            Debug.Log("LALALALALA 2");
    //        }
    //        _timeLeft = interval;
    //    }

    //}

    //IEnumerator EnemySpawn(GameObject enemy, Vector3 position, Quaternion rotation, float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    Debug.Log("LALALALALA");
    //    GameObject g = (GameObject)Instantiate(enemy, position, rotation);
    //    g.GetComponent<Enemy>().waypoints = waypoints.wayPoints;
        
    //}

}
