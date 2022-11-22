using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Title : MonoBehaviour {
    [Header("Game Events")]
    [SerializeField] GameEventSO InputLockEvent;
    [SerializeField] GameEventSO InputUnlockEvent;

    [Header("View")]
    [SerializeField] CanvasView Opening;

    [Header("Animator")]
    public RuntimeAnimatorController defaultAnimator;
    public RuntimeAnimatorController specialAnimator;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void ShowOpening() {
        if (PlayerPrefs.GetInt("OpeningVisited", 0) == 0) {
            Opening.Show();
        }
        else {
            animator.runtimeAnimatorController = GameManager.isSpecial ? specialAnimator : defaultAnimator;
            animator.Play("Intro");
        }
    }

    public void LockInput() {
        InputLockEvent.Dispatch();
    }

    public void UnlockInput() {
        InputUnlockEvent.Dispatch();
    }
}
