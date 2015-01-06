using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tesla : Tower {

    void Start() {
        buildPrice  = 1;
        interval    = 2.0f;
        range       = 10.0f;
        damage      = 10.0f;
    }

    public override void Fire(Enemy_Default target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        if(target) b.setDestination(target.transform);
        b.setDamage(damage);
        // reset time
        timeLeft = interval;
    }

}
