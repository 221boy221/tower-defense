using UnityEngine;
using System.Collections;

    // Swan

public class Enemy : MonoBehaviour {

    public Transform[] waypoints;
    protected float speed;
    protected float accuracy;
    protected float health;
    protected float damageReduction;
    protected float timeLeft = 0.0f;
    protected float interval = 2.0f;
    protected float slowInSeconds = 2f;
    protected float range = 10.0f;
    private Vector3 _velocity;
    private int _curWayPoint;
    private bool _canHeal = false;
    

    Enemy_Default findClosestTarget() {
        Enemy_Default closest = null;
        Vector3 pos = transform.position;

        Enemy_Default[] enemies = (Enemy_Default[])FindObjectsOfType(typeof(Enemy_Default));



        // If array isn't empty
        if (enemies != null) {
            if (enemies.Length > 0) {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i) {
                    float current = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);
                    // If the newly detected target is closer than the old (closest) target, set it to closest.
                    if (current < old){
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }
    
    public void Slow()
    {
        speed = 0.5f;
        Invoke("ResetSpeed", slowInSeconds);
    }
    private void ResetSpeed()
    {
        speed = 1;
    }

    // Use this for initialization
    void Start() {
        _curWayPoint = 0;
        _velocity = new Vector3();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        _canHeal = true;

    }

    // Update is called once per frame
    void Update() {

        if (_canHeal)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                _canHeal = false;
                StartCoroutine(FindTarget());
            }
        }

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
                        Debug.Log("Enemy got to the end");
                    }
                } else {
                    Debug.Log("Enemy is still alive");
                }
            }

            //apply velocity 
            transform.position = transform.position + _velocity * Time.deltaTime;
        }
        
    }

    IEnumerator FindTarget()
    {
        // Get closest target
        Enemy_Default target = findClosestTarget();
        if (target != null)
        {
            // Check if in range
            if (Vector3.Distance(transform.position, target.transform.position) <= range)
            {
                yield return new WaitForSeconds(1);
                // Ready to fire
                Fire(target);
                _canHeal = true;

            }
            
        }
       
    }

    public virtual void Fire(Enemy_Default target)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            if(Vector3.Distance(transform.position, enemy.transform.position) < range) {
                enemy.GetComponent<Enemy>().Heal(10);
            }
        }
    }
    
    public void Heal(float amount) {
        this.health += amount;
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
