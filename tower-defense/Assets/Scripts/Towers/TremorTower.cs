using UnityEngine;
using System.Collections;

public class TremorTower : Tower {

    void Start() {
        buildPrice  = 1;
        interval    = 0.5f;
        range       = 10.0f;
        damage      = 2.5f;
    }

    public override void Fire(EnemyBehaviour target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        b.setDestination(target.transform);
        b.setDamage(damage);
        // reset time
        timeLeft = interval;
    }

}
