using UnityEngine;
using System.Collections;

    // Boy

public class Player : MonoBehaviour {

    public GUISkin skin = null;
    public static int gold = 3; // start gold

    void OnGUI() {
        GUI.skin = skin;

        // draw gold
        GUI.Label(new Rect(0, 0, 400, 200), "Gold: " + gold);
    }

}
