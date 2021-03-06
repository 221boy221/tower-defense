﻿using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tesla : Tower {

    void Start() {

        buildPrice = 100;

        switch (lvl) {
            case 1:
                upgradePrice    = 200;
                interval        = 2.0f;
                range           = 3.0f;
                damage          = 25.0f;
                break;
            case 2:
                upgradePrice    = 400;
                interval        = 2.0f;
                range           = 4.0f;
                damage          = 50.0f;
                break;
            case 3:
                upgradePrice    = 999999999;
                interval        = 2.0f;
                range           = 4.0f;
                damage          = 75.0f;
                break;
        }

        destroyTime = 2.7f;

    }

    public override void Fire(Enemy target) {
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 0.1f), Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        if(target) b.setDestination(target.transform);
        b.setDamage(damage);
        b.setDestroyTime(0.1f);
        // reset time
        timeLeft = interval;
    }

}
