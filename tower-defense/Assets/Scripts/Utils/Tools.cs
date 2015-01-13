using UnityEngine;
using System.Collections;

    // Boy

public class Tools : MonoBehaviour {

    // Toggle SetActive
    public void Toggle(GameObject _object) {
        _object.SetActive(!_object.activeSelf);
    }

    // LoadScene
    public void LoadScene(string scene) {
        Application.LoadLevel(scene);
    }

}
