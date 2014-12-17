using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Smelter : Tower {

    void Start() {
        buildPrice  = 1;
        interval    = 4.0f;
        range       = 20.0f;
        damage      = 20.0f;
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
