using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy

public class Player : MonoBehaviour {

    public GUISkin skin = null;
    public Text goldText;
    public Text hpText;
    private int _gold = 250;
    private int _hp = 20;

    public AudioSource Source;

    public AudioClip EndOffTheLineAudio;
    public AudioClip NextWaveAudio;

    private void Start() {
        Source = GetComponent<AudioSource>();
        UpdateUI();
    }

    public void TakeDamage(int dmg) {
        Debug.Log("Dmg: " + dmg);
        _hp -= dmg;
        if (_hp <= 0) {
            GameOver();
        }
        UpdateUI();
    }

    public int Gold {
        get { return _gold; }
        //set { _gold = value; }
    }

    public void depleteGold(int amount) {
        _gold -= amount;
        UpdateUI();
    }

    public void earnGold(int amount) {
        _gold += amount;
        Debug.Log(amount);
        UpdateUI();
    }

    private void UpdateUI() {
        goldText.text = "" + _gold;
        hpText.text = "" + _hp;
    }

    private void GameOver() {
        Application.LoadLevel("GameOver");
    }

}
