using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Confirm : MonoBehaviour {
	public static Confirm Instance;

    public Text Text;
    public bool value { get; set; }

    UnityEvent OnConfirmEvent = new UnityEvent();

    void Awake() {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(string text, UnityAction action) {
        Text.text = text;
        OnConfirmEvent.AddListener(action);
        gameObject.SetActive(true);
    }

    public void Hide() {
        OnConfirmEvent.RemoveAllListeners();
        gameObject.SetActive(false);
    }

    public void OnClickYes() {
        value = true;
        OnConfirmEvent?.Invoke();
    }

    public void OnClickNo() {
        value = false;
        OnConfirmEvent?.Invoke();
    }
}
