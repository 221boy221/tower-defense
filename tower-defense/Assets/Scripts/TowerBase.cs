using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {

    public int price;
    public int upgradePrice;
    public int damage;
    public bool aoe;
    public bool slowEffect;

    public virtual void Shoot() {

    }

    public virtual void Seek() {

    }

}
