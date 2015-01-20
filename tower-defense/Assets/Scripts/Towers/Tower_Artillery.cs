using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Artillery : Tower {

    void Start() {

        buildPrice = 100;

        switch (lvl) {
            case 1:
                upgradePrice    = 200;
                interval        = 6.0f;
                range           = 6.0f;
                damage          = 50.0f;
                break;
            case 2:
                upgradePrice    = 400;
                interval        = 5.0f;
                range           = 12.0f;
                damage          = 75.0f;
                break;
            case 3:
                upgradePrice    = 999999999;
                interval        = 3.0f;
                range           = 12.0f;
                damage          = 75.0f;
                break;
        }

        destroyTime = 3.25f;
        
    }

    public override void Fire(Enemy target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 0.1f), Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        if(target) b.setDestination(target.transform);
        b.setDamage(damage);
        // reset time
        timeLeft = interval;
    }

}
