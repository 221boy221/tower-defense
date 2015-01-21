using UnityEngine;
using System.Collections;

    // Boy & Swan

public class Enemy_Healer : Enemy {

    //private bool _canHeal = false;
    //private float range = 10.0f;
    //private float interval = 0.5f;
    //private float timeLeft = 0.0f;

    void Start() {
        health          = 100.0f;
        damageReduction = 0.0f;
        speed           = 1.0f;
        destroyTime     = 2.0f;
        reward          = 25;
    }



    // Swan


    //------------------------Due to lack of time the healing ability has been canceled------------------------//
    /*
    void Awake()
    {
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        _canHeal = true;

    }

    void Update()
    {

        if (_canHeal)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                _canHeal = false;
                StartCoroutine(FindTarget());
            }
        }
    }

    Enemy findClosestTarget()
    {
        Enemy closest = null;
        Vector3 pos = transform.position;

        Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy));



        // If array isn't empty
        if (enemies != null)
        {
            if (enemies.Length > 0)
            {
                closest = enemies[0];
                for (int i = 1; i < enemies.Length; ++i)
                {
                    float current = Vector3.Distance(pos, enemies[i].transform.position);
                    float old = Vector3.Distance(pos, closest.transform.position);
                    // If the newly detected target is closer than the old (closest) target, set it to closest.
                    if (current < old)
                    {
                        closest = enemies[i];
                    }
                }
            }
        }

        return closest;
    }

    IEnumerator FindTarget()
    {
        // Get closest target
        Enemy target = findClosestTarget();
        if (target != null)
        {
            // Check if in range
            if (Vector3.Distance(transform.position, target.transform.position) <= range)
            {
                yield return new WaitForSeconds(1);
                // Ready to fire
                Fire(target);
                _canHeal = true;

            }

        }

    }

    public void Fire(Enemy_Default target) {
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
    }*/

}