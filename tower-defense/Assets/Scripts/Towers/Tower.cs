﻿using UnityEngine;
using System.Collections;

    // Boy
    // WOOO, I finally got the hang of inheritance in C# (kinda) :D

public class Tower : MonoBehaviour {

    private bool _canFire = false;
    private Animator _anim;
    protected float interval = 2.0f;
    protected float range = 10.0f;
    protected float timeLeft = 0.0f;
    protected float damage = 0.0f;
    public Bullet bulletPrefab = null;
    public int buildPrice = 1;    

    EnemyBehaviour findClosestTarget() {
        EnemyBehaviour closest = null;
        Vector3 pos = transform.position;

        EnemyBehaviour[] enemies = (EnemyBehaviour[])FindObjectsOfType(typeof(EnemyBehaviour));
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
        if (_canFire) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f) {
                _canFire = false;
                StartCoroutine(FindTarget());
            }
        }
    }

    IEnumerator FindTarget() {
        // Get closest target
        EnemyBehaviour target = findClosestTarget();
        if (target != null) {
            // Check if in range
            if (Vector3.Distance(transform.position, target.transform.position) <= range) {
                // Charging...
                if (_anim) _anim.Play("animFire");
                yield return new WaitForSeconds(1);
                // Ready to fire
                Fire(target);
                _canFire = true;

            } else {
                if (_anim) _anim.Play("animIdle");
            }
        } else {
            if (_anim) _anim.Play("animIdle");
        }
    }

    public virtual void Fire(EnemyBehaviour target) {

    }

    public virtual void OnMouseDown() {
        //towerUpgradeUI.SetActive(!towerUpgradeUI.activeSelf);
    }

}