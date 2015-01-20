using UnityEngine;
using System.Collections;

    // Boy

public class TowerSlot : MonoBehaviour {

    public GUISkin skin = null;
    public Tower[] towers = null;
    public Tower[] towersLvl2 = null;
    public Tower[] towersLvl3 = null;
    public GameObject buyMenu;      // Where you can buy towers
    public GameObject towerMenu;    // Where you upgrade or sell the current tower
    private bool _occupied = false;
    private int _towerType;
    private int _checkLvl;
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
        if (_player.Gold >= towers[_towerType].GetBuildPrice()) {
            // Remove gold
            _player.depleteGold(towers[_towerType].GetBuildPrice());
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

    // New Unity UI will run this
    public void UpgradeTower() {
        StartCoroutine(Upgrade());
    }

    // Which then triggers this, since the UI can't trigger IEnumerators
    IEnumerator Upgrade() {
        if (_player.Gold >= _tower.GetUpgradePrice()) {
            _player.depleteGold(_tower.GetUpgradePrice());
            _checkLvl = _tower.lvl + 1;
            _tower.SellTower();

            // Hide menu if active to prevent upgrade spam glitch
            towerMenu.SetActive(false);

            yield return new WaitForSeconds(_tower.destroyTime);
            // Spawn new Tower
            switch (_checkLvl) {
                case 2:
                    _tower = (Tower)Instantiate(towersLvl2[_towerType], transform.position, Quaternion.identity);
                    break;
                case 3:
                    _tower = (Tower)Instantiate(towersLvl3[_towerType], transform.position, Quaternion.identity);
                    break;
                default:
                    _tower = (Tower)Instantiate(towersLvl3[_towerType], transform.position, Quaternion.identity);
                    break;
            }
            _tower.lvl = _checkLvl;
            

            // Hide menu if active
            towerMenu.SetActive(false);
        }
    }

    public void SellTower() {
        // Remove tower
        _tower.SellTower();
        // Return 2/3th of gold from the buildPrice
        _player.earnGold(_tower.GetBuildPrice() - (_tower.GetBuildPrice() / 3));
        // Slot is no longer occupied
        _occupied = false;
        // Hide active menu
        towerMenu.SetActive(false);
    }

}
