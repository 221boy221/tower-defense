using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy

public class Player : MonoBehaviour {

    public GUISkin skin = null;
    public Text goldText;
    public Text hpText;
    public static int gold = 150; // start gold
    private int _hp = 20;

    private void Start() {
        UpdateUI();
    }

    public void TakeDamage(int dmg) {
        Debug.Log(dmg);
        _hp -= dmg;
        if (_hp <= 0) {
            GameOver();
        }
        UpdateUI();
    }

    private void UpdateUI() {
        goldText.text = "" + gold;
        hpText.text = "" + _hp;
    }

    private void GameOver() {
        Application.LoadLevel("GameOver");
    }

}
