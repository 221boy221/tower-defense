using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Slow : Enemy {
    
    void Start() {
        speed = 0.3f;
        accuracy = 0.1f;
        health = 200.0f;
        damageReduction = 0.0f;
        reward = 50;
        destroyTime = 2.5f;
    }

}