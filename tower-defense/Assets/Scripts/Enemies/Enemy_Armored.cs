﻿using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Armored : Enemy {
    
    void Start() {
        health          = 150.0f;
        damageReduction = 0.8f; // dmg received * value. Put it between 0.0f and 1.0f, where as 1 is no reduction and 0 makes you invincible.
        speed           = 0.3f;
        destroyTime     = 3.0f;
        reward          = 45;
    }

}