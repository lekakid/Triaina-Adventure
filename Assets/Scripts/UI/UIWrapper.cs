using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWrapper : MonoBehaviour {
    public bool onAwakeActive;

    void Awake() {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        gameObject.SetActive(onAwakeActive);
    }
}
