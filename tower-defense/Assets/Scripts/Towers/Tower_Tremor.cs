using UnityEngine;
using System.Collections;

    // Boy

public class Tower_Tremor : Tower {

    private float _cooldown;

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
                interval    = 3.0f;
                range       = 3.0f;
                damage      = 20.0f;
                break;
        }
    }

    public override void Fire(Enemy target) {
        
        //check all enemies
        Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy_Default));
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
