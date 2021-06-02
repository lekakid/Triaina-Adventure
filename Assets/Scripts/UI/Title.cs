using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {
    [SerializeField] GameEventSO OpeningEvent;
    [SerializeField] GameEventSO InitializeEvent;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

	public void OnClickPlay() {
        if (PlayerPrefs.GetInt("OpeningVisited", 0) > 0) {
            InitializeEvent.Dispatch();
        }
        else {
            OpeningEvent.Dispatch();
        }
        animator.Play("Hide");
    }
}
