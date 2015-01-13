using UnityEngine;
using System.Collections;

    // Boy

public class Player : MonoBehaviour {

    public GUISkin skin = null;
    public static int gold = 150; // start gold
    public static int hp = 20;

    void OnGUI() {
        GUI.skin = skin;

        // temp UI
        GUI.Label(new Rect(0, 0, 400, 200), "Gold: " + gold);
        GUI.Label(new Rect(0, 20, 400, 200), "HP: " + hp);
        
    }

}
