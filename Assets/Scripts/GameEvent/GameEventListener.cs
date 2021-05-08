using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
	public GameEventSO EventSO;

    [SerializeField] UnityEvent EventCallback;

    void OnEnable() {
        if(EventSO == null) return;

        EventSO.Register(this);
    }

    void OnDisable() {
        if(EventSO == null) return;
        
        EventSO.Deregister(this);
    }

    public void InvokeCallback() {
        EventCallback.Invoke();
    }
}
