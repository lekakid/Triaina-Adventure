using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour {
    [SerializeField] string Type;

    void Awake() {
        if(PlayerPrefs.GetInt($"{Type}Visited", 0) > 0) {
            gameObject.SetActive(false);
        }
    }
}
