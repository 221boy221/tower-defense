using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Healer : Enemy {
    
    void Start() {
        speed = 1.0f;
        accuracy = 0.1f;
        health = 100.0f;
        damageReduction = 0.0f;
        interval = 0.5f;
    }

    public override void Fire(Enemy_Default target) {
        //check all enemies
        Enemy_Default[] enemies = (Enemy_Default[])FindObjectsOfType(typeof(Enemy_Default));
        // If array isn't empty
        if (enemies != null) {
            if (enemies.Length > 0) {
                for (int i = 1; i < enemies.Length; ++i) {
                    //check if enemies are in range then slow current enemy
                    if (Vector3.Distance(this.transform.position, enemies[i].transform.position) <= range) {
                        //slowing current enemy
                        enemies[i].Slow();
                    }
                }
            }
        }
        // reset time
        timeLeft = interval;
    }
}