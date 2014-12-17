using UnityEngine;
using System.Collections;

    // Boy

public class TowerSlot : MonoBehaviour {

    public GUISkin skin = null;
    public Tower[] towers = null;
    public GameObject towerMenuUI;
    
    void Start() {
        towerMenuUI.SetActive(false);
    }

    public void OnMouseDown() {
        towerMenuUI.SetActive(!towerMenuUI.activeSelf);
    }

    public void BuildTower(int towerType) {
        if (Player.gold >= towers[towerType].buildPrice) {
            Player.gold -= towers[towerType].buildPrice;

            Instantiate(towers[towerType], transform.position, Quaternion.identity);

            // Will be enabled again if tower is sold.
            gameObject.SetActive(false);
        }
    }

}
