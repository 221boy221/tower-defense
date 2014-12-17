using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Default : Enemy {
    
    void Start() {
        speed = 1.0f;
        accuracy = 0.1f;
        health = 100.0f;
        damageReduction = 0.0f;
    }

}