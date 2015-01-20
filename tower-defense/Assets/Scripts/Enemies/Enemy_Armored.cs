using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Armored : Enemy {
    
    void Start() {
        speed = 0.5f;
        accuracy = 0.1f;
        health = 100.0f;
        damageReduction = 0.0f;
        reward = 25;
        destroyTime = 3.0f;
    }

}