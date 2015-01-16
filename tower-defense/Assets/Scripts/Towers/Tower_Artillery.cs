using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Artillery : Tower {

    void Start() {
        switch (lvl) {
            case 1:
                buildPrice  = 100;
                interval    = 5.0f;
                range       = 10.0f;
                damage      = 50.0f;
                break;
            case 2:
                buildPrice  = 200;
                interval    = 5.0f;
                range       = 15.0f;
                damage      = 75.0f;
                break;
        }
        
    }

    public override void Fire(Enemy target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z) /*transform.position*/, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        if(target) b.setDestination(target.transform);
        b.setDamage(damage);
        // reset time
        timeLeft = interval;
    }

}
