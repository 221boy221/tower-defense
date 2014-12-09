using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float movementSpeed = 1 ;
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
	}
}
