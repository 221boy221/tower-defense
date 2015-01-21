using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Slow : Enemy {
    
    void Start() {
        health          = 150.0f;
        damageReduction = 0.0f;
        speed           = 0.3f;
        destroyTime     = 2.5f;
        reward          = 35;
    }

}