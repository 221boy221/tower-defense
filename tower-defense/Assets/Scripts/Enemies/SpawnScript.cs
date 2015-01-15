using UnityEngine;
using System.Collections;

    // Swan

public class SpawnScript : MonoBehaviour {

    public WaypointTest waypoints;
    private int _waveCounter = 0;
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
            _waveCounter++;
        }
    }
}
