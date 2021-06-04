using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Title : MonoBehaviour {
    [Header("Game Events")]
    [SerializeField] GameEventSO InputLockEvent;
    [SerializeField] GameEventSO InputUnlockEvent;

    [Header("Unity Events")]
    [SerializeField] UnityEvent FirstPlayEvent;
    [SerializeField] UnityEvent NormalPlayEvent;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

	public void Play() {
        if (PlayerPrefs.GetInt("OpeningVisited", 0) > 0) {
            NormalPlayEvent.Invoke();
        }
        else {
            FirstPlayEvent.Invoke();
        }
    }

    public void LockInput() {
        InputLockEvent.Dispatch();
    }

    public void UnlockInput() {
        InputUnlockEvent.Dispatch();
    }
}
