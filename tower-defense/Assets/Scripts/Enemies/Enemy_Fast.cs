using UnityEngine;
using System.Collections;

    // Boy

public class Enemy_Fast : Enemy {
    
    void Start() {
        health          = 50.0f;
        speed           = 1.0f;
        destroyTime     = 1.5f;
        reward          = 10;
    }

}