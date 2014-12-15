using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public WaypointTest waypoints;
    public GameObject[] enemyTypes;
    private int currentEnemyIndex = -1;

    public float interval = 3.0f;
    float timeLeft = 0.0f;

    GameObject[] enemyWaves;


    //void Awake()
    //{
    //    //Get a reference to each ship (for efficiency)
    //    enemyWaves = new GameObject[transform.childCount];
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        enemyWaves[i] = transform.GetChild(i).gameObject;
    //    }
    //}

    //void OnEnable()
    //{
    //    //When enabled, activate each child
    //    foreach (GameObject obj in enemyWaves)
    //    {
    //        obj.SetActive(true);
    //    }
    //}

    void Update()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {

            // enemy sequance
            currentEnemyIndex++;
            if (currentEnemyIndex >= enemyTypes.Length) currentEnemyIndex = 0;

            Debug.Log("derp");

            GameObject g = (GameObject)Instantiate(enemyTypes[currentEnemyIndex], transform.position, Quaternion.identity);
            g.GetComponent<EnemyScript>().waypoints = waypoints.wayPoints;

            timeLeft = interval;
        }

    }
}
