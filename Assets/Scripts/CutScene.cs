using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene : MonoBehaviour {
    [SerializeField] GameEventSO InputBlockEvent;
    [SerializeField] GameEventSO InputUnblockEvent;

    [SerializeField] UnityEvent OnHide;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetVisit(string type) {
        PlayerPrefs.SetInt($"{type}Visited", 1);
    }

    public void Hide() {
        gameObject.SetActive(false);
        OnHide.Invoke();
    }

    public void NextScene() {
        animator.SetTrigger("Next");
    }

    public void BlockInput() {
        InputBlockEvent.Dispatch();
    }

    public void UnblockInput() {
        InputUnblockEvent.Dispatch();
    }
}
