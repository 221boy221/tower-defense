using System.Collections;
using UnityEngine;

    // Swan

public class Enemy : MonoBehaviour {

    // Default values in case the childs do not overwrite, to avoid 'Null' runtime errors.

    public Transform[] waypoints;
    public bool dead                = false;
    protected float health          = 50.0f;
    protected float damageReduction = 1.0f; // dmg received * value. Put it between 0.0f and 1.0f, where as 1 is no reduction and 0 makes you invincible.
    protected float speed           = 1.0f;
    protected float slowInSeconds   = 2.0f;
    protected float destroyTime     = 2.0f;
    protected int reward            = 10;
    protected int dmg               = 1;
    private float accuracy          = Random.Range(0.05f, 0.5f);
    private bool _alive             = true;
    private int _curWayPoint;
    private Vector3 _velocity;
    private Animator _anim;
    private Player _player;

    //private Vector3 _prevLoc = Vector3.zero;

    void Awake() {
        _anim = GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("GameController").GetComponent<Player>();
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
                        // Play audio
                        _player.Source.PlayOneShot(_player.EndOffTheLineAudio, 1f);
                        // Get rid of the object
                        Destroy(gameObject);
                        // Deal damage to the player's hp
                        _player.TakeDamage(dmg);
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
        // Slow enemy's speed
        speed = speed / slowAmount;
        // Wait a few seconds (The time the enemies are slowed)
        yield return new WaitForSeconds(slowInSeconds);
        // Set his speed back to normal
        speed = speed * slowAmount;
    }

    // Get healed
    public void Heal(float amount) {
        health += amount;
    }

    // Take damage
    public void TakeDamage(float dmg) {
        // If the enemy happens to have armor
        dmg = dmg * damageReduction;
        if (dmg < 0) dmg = 0;

        // Actually deal damage
        health -= dmg;
        if (health <= 0) Dead();
    }

    // Destroy and give Reward
    private void Dead() {
        // Check if he ain't dead already, in case multiple bullets still have him as target.
        if (dead) return;
        dead = true;

        // Give the player gold as a reward
        _player.earnGold(reward);
        // Play death anim
        _anim.Play("animDeath");
        // Disable movement
        _alive = false;
        // Destroy but wait for the destroyTime first (which is the length of the enemy's death animation)
        Destroy(gameObject, destroyTime);
    }

}
