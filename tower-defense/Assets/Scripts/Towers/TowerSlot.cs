using UnityEngine;
using System.Collections;

    // Boy

public class TowerSlot : MonoBehaviour {

    public GUISkin skin = null;
    public Tower[] towers = null;
    public Tower[] upgradedTowers = null;
    public GameObject buyMenu;      // Where you can buy towers
    public GameObject towerMenu;    // Where you upgrade or sell the current tower
    private bool _occupied = false;
    private int _towerType;
    private Tower _tower;
    private Player _player;
    
    
    void Start() {
        buyMenu.SetActive(false);
        towerMenu.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("GameController").GetComponent<Player>();
    }

    public void OnMouseDown() {
        // Show menu on click
        if (!_occupied) {
            buyMenu.SetActive(!buyMenu.activeSelf);
        } else {
            towerMenu.SetActive(!towerMenu.activeSelf);
        }
    }

    public void BuildTower(int towerType) {
        if (_player.Gold >= towers[_towerType].buildPrice) {
            // Remove gold
            _player.depleteGold(towers[_towerType].buildPrice);
            // Save the type for later use
            _towerType = towerType;
            // Spawn tower
            _tower = (Tower)Instantiate(towers[_towerType], transform.position, Quaternion.identity);
            // Slot is now occupied
            _occupied = true;
            // Hide active menu
            buyMenu.SetActive(false);
        }
    }

    public void UpgradeTower() {
        if (_player.Gold >= _tower.upgradePrice) {
            _player.depleteGold(_tower.upgradePrice);

            _tower.SellTower();

            // Spawn lvl 2 tower
            _tower = (Tower)Instantiate(upgradedTowers[_towerType], transform.position, Quaternion.identity);
            _tower.lvl = 2;

            // Hide menu if active
            towerMenu.SetActive(false);
        }
    }

    public void SellTower() {
        // Remove tower
        _tower.SellTower();
        // Return gold
        _player.earnGold(_tower.buildPrice - (_tower.buildPrice / 3));
        // Slot is no longer occupied
        _occupied = false;
        // Hide active menu
        towerMenu.SetActive(false);
    }

}
