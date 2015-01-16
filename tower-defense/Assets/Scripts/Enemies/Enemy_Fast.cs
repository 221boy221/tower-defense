using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Fast : Enemy {
    
    void Start() {
        speed = 1.0f;
        accuracy = 0.1f;
        health = 50.0f;
        damageReduction = 0.0f;
        reward = 15;
        destroyTime = 1.0f;
    }

}