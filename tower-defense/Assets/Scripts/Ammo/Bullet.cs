﻿using UnityEngine;
using System.Collections;

    // Boy

public class Bullet : MonoBehaviour {

    private float _destroyTime  = 0.0f;
    private float _damage       = 0.0f;
    private float _speed        = 0.5f;
    private float _collDistance = 1.0f;
    private float _arch         = 2.0f;
    private bool _ignore        = false;
    private float _z;
    private Vector3 _velocity;
    private Transform _destination;

    void Start() {
        _z = transform.position.z;
        _velocity = new Vector3(0, _arch, 0);
    }

    void Update() {
        // Destroy bullet if _destination does not exist anymore
        if (_destination == null) {
            Destroy(gameObject);
            return;
        }

        // Get step to target
        CalcStep();

        // Rotation
        transform.rotation = Quaternion.EulerAngles(0, 0, Mathf.Atan2(_velocity.y, _velocity.x));

        // Fly towards the destination
        Movement();

        // When reached
        if (Vector2.Distance(transform.position, _destination.position) < _collDistance && !_ignore) {
            HitTarget();
        }
    }

    private void Movement() {
        // Fly towards the destination, make sure to keep it's Z so that it doesn't go behind the towers and enemies.
        transform.position = transform.position + (_velocity * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, _z);
    }

    private void CalcStep() {
        // Calculate step to target
        Vector3 offset = _destination.position - transform.position;
        offset.Normalize();
        offset = offset * _speed;
        _velocity = _velocity + offset;
    }

    private void HitTarget() {
        Enemy enemy = _destination.GetComponent<Enemy>();
        enemy.TakeDamage(_damage);
        _ignore = true;
        // Slight delay
        Destroy(gameObject, _destroyTime);
    }

    public void setDamage(float dmg) {
        _damage = dmg;
    }

    public void setDestroyTime(float time) {
        _destroyTime = time;
    }

    public void setDestination(Transform target) {
        _destination = target;
    }

}
