using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Default : Enemy {
    
    void Start() {
        speed = 0.5f;
        accuracy = 0.1f;
        health = 100.0f;
        damageReduction = 0.0f;
        reward = 20;
        destroyTime = 2.5f;
    }

    
}