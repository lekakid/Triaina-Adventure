using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Project/GameEvent")]
public class GameEventSO : ScriptableObject {
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void Register(GameEventListener listener) {
        listeners.Add(listener);
    }

    public void Deregister(GameEventListener listener) {
        listeners.Remove(listener);
    }

	public void Dispatch() {
        for(int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].InvokeCallback();
        }
    }
}
