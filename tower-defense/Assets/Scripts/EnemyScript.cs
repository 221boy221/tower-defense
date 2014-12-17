using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    //public GameObject waypoint;
    public float speed;
    public float accuracy;

    public Transform[] waypoints;
    private int curWayPoint;
    private Vector3 velocity;

    /*public float hitpoints;
    *public GameObject;
    *public float spawnWaitTime;*/

    // Use this for initialization
    void Start()
    {
        curWayPoint = 0;
        velocity = new Vector3();
        //InvokeRepeating ("Spawn", 1, spawnWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(...(0)) 
             {
             hitpoints -= ...;
         
             if (hitpoints <= 0) 
             {
                 Death();
             }
         }*/
        if (curWayPoint < waypoints.Length)
        {
            //float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, waypoints[curWayPoint].transform.position, step);

            Vector3 step = waypoints[curWayPoint].transform.position - transform.position;
            step.Normalize();
            step *= speed;

            velocity = step;

            if (Vector3.Distance(transform.position, waypoints[curWayPoint].transform.position) < accuracy)
            {
                if (curWayPoint != waypoints.Length)
                {
                    curWayPoint++;
                    if (curWayPoint >= waypoints.Length)
                    {
                        Destroy(this.gameObject);
                        Debug.Log("derp is dead");
                    }
                }
                else
                {
                    Debug.Log("derp is alive");
                }
            }

            //apply velocity 
            transform.position = transform.position + velocity * Time.deltaTime;
        }

    }
    /*void Death() {
          //gameObject.renderer.enabled = false;
            Destroy(gameObject);
            WaitForSeconds(3);
            Debug.Log("derp is dead");
            Spawn();
        }*/

    /*void Spawn() {
        var newEnemy = Instantiate(enemy, transform.position, transform.rotation);
    }*/
}
