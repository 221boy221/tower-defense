using UnityEngine;
using System.Collections;

    // Boy

public class Bullet : MonoBehaviour {

    public float _damage = 0.0f;

    private Vector3 _velocity;
    private Transform _destination;
    private float _speed = 0.5f;
    private float _collisionDistance = 1.0f;
    private float _arch = 2.0f;
    private bool _ignore = false;

    void Start() {
        _velocity = new Vector3(0, _arch, 0);
    }

    void Update() {
        // Destroy bullet if _destination does not exist anymore
        if (_destination == null) {
            Destroy(gameObject);
            return;
        }

        // Calculate step to target
        Vector3 offset = _destination.position - transform.position;
        offset.Normalize();
        offset = offset * _speed;
        _velocity = _velocity + offset;

        // Rotation
        transform.rotation = Quaternion.EulerAngles(0, 0, Mathf.Atan2(_velocity.y, _velocity.x));

        // Fly towards the _destination
        transform.position = transform.position + (_velocity * Time.deltaTime);

        // When reached
        if (Vector3.Distance(transform.position, _destination.position) < _collisionDistance && !_ignore) {
            Enemy enemy = _destination.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
            _ignore = true;
            // Slight delay
            Destroy(gameObject, 0.1f);
        }
    }

    public void setDamage(float dmg) {
        _damage = dmg;
    }

    public void setDestination(Transform target) {
        _destination = target;
    }

}
