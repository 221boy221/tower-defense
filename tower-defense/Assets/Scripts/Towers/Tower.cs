using UnityEngine;
using System.Collections;

    // Boy
    // WOOO, I finally got the hang of inheritance in C# (kinda) :D

public class Tower : MonoBehaviour {

    public Bullet bulletPrefab  = null;
    public int buildPrice       = 100;
    protected float interval    = 2.0f;
    protected float range       = 10.0f;
    protected float timeLeft    = 0.0f;
    protected float damage      = 0.0f;
    private bool _canFire       = false;
    private bool _beingSold     = false;
    private Animator _anim;

    Enemy findClosestTarget() {
        Enemy closest = null;
        Vector3 pos = transform.position;

        Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy));
        // If array isn't empty
        if (enemies != null) {
            if (enemies.Length > 0) {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i) {
                    float current = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);
                    // If the newly detected target is closer than the old (closest) target, set it to closest.
                    if (current < old) {
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }

    void Awake() {
        StartCoroutine(Delay());
        _anim = GetComponentInChildren<Animator>();
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(6);
        _canFire = true;

    }

    void Update() {
        if (_canFire && !_beingSold) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f) {
                _canFire = false;
                StartCoroutine(FindTarget());
            }
        }
    }

    IEnumerator FindTarget() {
        // Get closest target
        Enemy target = findClosestTarget();
        if (target != null) {
            // Check if in range
            if (Vector3.Distance(transform.position, target.transform.position) <= range) {
                // Charging...
                if (_anim) _anim.Play("animFire");
                yield return new WaitForSeconds(1);
                // Ready to fire
                Fire(target);
                // Is done shooting.
                _canFire = true;

            } else {
                if (_anim) _anim.Play("animIdle");
            }
        } else {
            if (_anim) _anim.Play("animIdle");
        }
    }

    public virtual void Fire(Enemy target) {

    }

    public virtual void OnMouseDown() {
        //towerUpgradeUI.SetActive(!towerUpgradeUI.activeSelf);
    }

    public void SellTower() {
        // Disable the ability to fire
        _beingSold = true;
        // Play the sell anim
        _anim.Play("animSell");
        // Get rid of the tower
        DestroyObject(gameObject, 3.5f);
    }

}
