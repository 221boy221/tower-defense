using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Smelter : Tower {

    void Start() {
        buildPrice  = 100;
        interval    = 0.5f;
        range       = 5.0f;
        damage      = 5.0f;
    }

    public override void Fire(Enemy target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set damage
        b.setDamage(damage);
        // set destination
        if (target) b.setDestination(target.transform);
        // reset time
        timeLeft = interval;
    }

}
