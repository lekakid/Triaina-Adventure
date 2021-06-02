using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour {
    [SerializeField] GameEventSO InputBlockEvent;
    [SerializeField] GameEventSO InputUnblockEvent;
    [SerializeField] GameEventSO InitializeEvent;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetVisit() {
        PlayerPrefs.SetInt("OpeningVisited", 1);
    }

    public void Hide() {
        gameObject.SetActive(false);
        InitializeEvent.Dispatch();
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
