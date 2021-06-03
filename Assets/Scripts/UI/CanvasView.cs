using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasView : MonoBehaviour {
	[SerializeField] bool onAwakeShow;

    [SerializeField] UnityEvent OnShow;
    [SerializeField] UnityEvent OnHide;

    void Awake() {
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;

        gameObject.SetActive(onAwakeShow);
    }

    void Start() {
        if(onAwakeShow) Show();
    }

    public void Show() {
        if(OnShow != null) {
            OnShow.Invoke();
        }
    }

    public void Hide() {
        if(OnHide != null) {
            OnHide.Invoke();
        }
    }

    public void Toggle() {
        if(gameObject.activeSelf) {
            Hide();
        }
        else {
            Show();
        }
    }
}
