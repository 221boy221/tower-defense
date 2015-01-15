using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tesla : Tower {

    void Start() {
        buildPrice  = 100;
        interval    = 2.0f;
        range       = 3.0f;
        damage      = 25.0f;
    }

    public override void Fire(Enemy target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) /*transform.position*/, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        if(target) b.setDestination(target.transform);
        b.setDamage(damage);
        // reset time
        timeLeft = interval;
    }

}
