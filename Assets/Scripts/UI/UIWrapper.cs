using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWrapper : MonoBehaviour {
    public bool onAwakeActive;

    void Awake() {
        transform.position = new Vector2(4.5f, 8f);
        gameObject.SetActive(onAwakeActive);
    }
}
