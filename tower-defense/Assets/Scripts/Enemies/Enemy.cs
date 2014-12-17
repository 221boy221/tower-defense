using UnityEngine;
using System.Collections;

    // Swan

public class Enemy : MonoBehaviour {

    public Transform[] waypoints;
    protected float speed;
    protected float accuracy;
    protected float health;
    protected float damageReduction;
    private Vector3 _velocity;
    private int _curWayPoint;

    // Use this for initialization
    void Start() {
        _curWayPoint = 0;
        _velocity = new Vector3();
    }

    // Update is called once per frame
    void Update() {
        if (_curWayPoint < waypoints.Length) {

            Vector3 step = waypoints[_curWayPoint].transform.position - transform.position;
            step.Normalize();
            step *= speed;

            _velocity = step;

            if (Vector3.Distance(transform.position, waypoints[_curWayPoint].transform.position) < accuracy) {
                if (_curWayPoint != waypoints.Length) {
                    _curWayPoint++;
                    if (_curWayPoint >= waypoints.Length) {
                        Destroy(this.gameObject);
                        Debug.Log("Enemy is dead");
                    }
                } else {
                    Debug.Log("Enemy is alive");
                }
            }

            //apply velocity 
            transform.position = transform.position + _velocity * Time.deltaTime;
        }

    }

    // Take damage
    public void TakeDamage(float dmg) {

        dmg -= damageReduction;
        if (dmg < 0) dmg = 0;

        health -= dmg;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
