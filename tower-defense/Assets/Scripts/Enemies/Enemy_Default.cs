using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Default : Enemy {
    
    void Start() {
        health          = 75.0f;
        damageReduction = 0.0f;
        speed           = 0.5f;
        destroyTime     = 2.5f;
        reward          = 25;
    }

}