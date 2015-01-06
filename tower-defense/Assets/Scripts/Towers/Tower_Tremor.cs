using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tremor : Tower {
    private float _cooldown;
    void Start() {
        buildPrice  = 1;
        interval    = 0.5f;
        range       = 10.0f;
        damage      = 2.5f;
    }

    public override void Fire(Enemy_Default target) {
        /*
        // spawn bullet
        GameObject g = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
        // get access to bullet component
        Bullet b = g.GetComponent<Bullet>();
        // set destination
        b.setDestination(target.transform);
        b.setDamage(damage);
        Vector3 pos = transform.position;
        */
        //check all enemies
        Enemy_Default[] enemies = (Enemy_Default[])FindObjectsOfType(typeof(Enemy_Default));
        // If array isn't empty
        if (enemies != null)
        {
            if (enemies.Length > 0)
            {
                for (int i = 1; i < enemies.Length; ++i)
                {
                    //check if enemies are in range then slow current enemy
                    if (Vector3.Distance(this.transform.position, enemies[i].transform.position) <= range)
                    {
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
