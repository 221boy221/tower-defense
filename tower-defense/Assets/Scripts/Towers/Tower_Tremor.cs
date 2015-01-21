using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tremor : Tower {

    private float _cooldown;

    void Start() {

        buildPrice = 100;

        switch (lvl) {
            case 1:
                upgradePrice    = 200;
                interval        = 6.0f;
                range           = 2.0f;
                damage          = 10.0f;
                break;
            case 2:
                upgradePrice    = 400;
                interval        = 4.5f;
                range           = 3.0f;
                damage          = 20.0f;
                break;
            case 3:
                upgradePrice    = 999999999;
                interval        = 4.0f;
                range           = 3.5f;
                damage          = 25.0f;
                break;
        }

        destroyTime = 3.167f;
        fireDelay   = 4.0f;
    }

    public override void Fire(Enemy target) {
        //check all enemies
        Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy));
        // If array isn't empty
        if (enemies != null) {
            if (enemies.Length > 0) {
                for (int i = 1; i < enemies.Length; i++) {
                    //check if enemies are in range then slow current enemy
                    if (Vector3.Distance(transform.position, enemies[i].transform.position) <= range) {
                        //slowing current enemy
                        enemies[i].SlowEnemy(4);
                    }
                }
            }
        }
        // reset time
        timeLeft = interval;
    }
}
