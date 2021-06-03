using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Title : MonoBehaviour {
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
}
