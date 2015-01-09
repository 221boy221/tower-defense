using UnityEngine;
using System.Collections;

    // Boy

public class TowerSlot : MonoBehaviour {

    public GUISkin skin = null;
    public Tower[] towers = null;
    public GameObject buyMenu;      // Where you can buy towers
    public GameObject towerMenu;    // Where you upgrade or sell the current tower
    private bool occupied = false;
    private int towerID;
    private Tower tower;
    private Animator anim;
    
    void Start() {
        buyMenu.SetActive(false);
        towerMenu.SetActive(false);
    }

    public void OnMouseDown() {
        // Show menu on click
        if (!occupied) {
            buyMenu.SetActive(!buyMenu.activeSelf);
        } else {
            towerMenu.SetActive(!towerMenu.activeSelf);
        }
    }

    public void BuildTower(int towerType) {
        if (Player.gold >= towers[towerType].buildPrice) {
            // Remove gold
            Player.gold -= towers[towerType].buildPrice;
            // Spawn tower
            tower = (Tower) Instantiate(towers[towerType], transform.position, Quaternion.identity);
            anim = tower.GetComponent<Animator>();
            // Slot is now occupied
            occupied = true;
            // Hide active menu
            buyMenu.SetActive(false);
        }
    }

    public void UpgradeTower() {

    }

    public void SellTower() {
        // Remove tower
        //tower //animation.Play("animSell");
        anim.Play("animSell");

        DestroyObject(tower.gameObject, 4);
        // Return gold
        Player.gold += tower.buildPrice;
        // Slot is no longer occupied
        occupied = false;
        // Hide active menu
        towerMenu.SetActive(false);
    }

}
