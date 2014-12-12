using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

    public void Toggle(GameObject _object) {
        _object.SetActive(!_object.activeSelf);
    }
    
}
