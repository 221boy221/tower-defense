using System.Collections;
using UnityEngine;

    // Swan

public class Enemy : MonoBehaviour {

    public Transform[] waypoints;
    public bool dead = false;
    protected float speed;
    protected float accuracy;
    protected float health;
    protected float damageReduction;
    protected float timeLeft = 0.0f;
    protected float interval = 2.0f;
    protected float slowInSeconds = 2f;
    protected float range = 10.0f;
    protected float destroyTime = 2.0f;
    protected int reward = 10;
    protected int dmg = 1;
    private int _curWayPoint;
    private bool _alive = true;
    private Vector3 _velocity;
    //private Vector3 _prevLoc = Vector3.zero;
    private Animator _anim;
    private Player _player;

    void Awake() {
        _anim = GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("GameController").GetComponent<Player>();
    }

    void Start() {
        _curWayPoint = 0;
        _velocity = new Vector3();
    }

    void Update() {
        if (!_alive) return;

        if (_curWayPoint < waypoints.Length) {
            Vector3 step = waypoints[_curWayPoint].transform.position - transform.position;
            step.Normalize();
            step *= speed;

            _velocity = step;

            if (Vector3.Distance(transform.position, waypoints[_curWayPoint].transform.position) < accuracy) {
                if (_curWayPoint != waypoints.Length) {
                    _curWayPoint++;
                    if (_curWayPoint >= waypoints.Length) {
                        Destroy(gameObject);
                        // Deal damage to the player's hp
                        _player.TakeDamage(dmg);
                        Debug.Log("Enemy got to the end");
                    }
                }
            }

            //apply velocity 
            transform.position = transform.position + _velocity * Time.deltaTime;

            // This doesn't work as it is right now, the loop will spam Play the animation.
            #region Animations that are played when facing certain directions
            /*
            Vector3 curVel = (transform.position - _prevLoc) / Time.deltaTime;
                 if(curVel.y > 0) {
                     Debug.Log("walkUp");
                     //_anim.Play("animUp");
                 } else {
                     Debug.Log("walkDown");
                     //_anim.Play("animDown");

                 }

                 if (curVel.x > 0)
                 {
                     Debug.Log("walkRight");
                     //_anim.Play("animRight");
                 } else {
                     Debug.Log("walkLeft");
                     //_anim.Play("animLeft");
                 }
                 _prevLoc = transform.position;

            */
            #endregion

        }
    }

    // Tremor tower will trigger this
    public void SlowEnemy(int slowAmount) {
        StartCoroutine(Slow(slowAmount));
    }
    // Which then triggers this
    IEnumerator Slow(int slowAmount) {
        speed = speed / slowAmount;
        yield return new WaitForSeconds(slowInSeconds);
        speed = speed * slowAmount;
    }

    // Get healed
    public void Heal(float amount) {
        health += amount;
    }

    // Take damage
    public void TakeDamage(float dmg) {
        dmg -= damageReduction;
        if (dmg < 0) dmg = 0;

        health -= dmg;
        if (health <= 0) Dead();
    }

    // Destroy and give Reward
    private void Dead() {
        if (dead) return;
        dead = true;

        // Give the player gold as a reward
        _player.earnGold(reward);
        Debug.Log("Dead, reward is: " + reward);
        // Play death anim
        _anim.Play("animDeath");
        // Disable movement
        _alive = false;
        // Destroy
        Destroy(gameObject, destroyTime);
    }

}
