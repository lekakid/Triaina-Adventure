using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour {
    [Header("Events")]
    [SerializeField] GameEventSO TitleEvent;
    [SerializeField] GameEventSO InitializeEvent;
    [SerializeField] GameEventSO StartEvent;
    [SerializeField] GameEventSO PauseEvent;
    [SerializeField] GameEventSO ResumeEvent;

    Player player;

    void Awake() {
        player = GetComponent<Player>();
    }

	void Update() {
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0)) return;

        switch(GameManager.State) {
            case GameManager.GameState.TITLE:
            OnTitle();
            break;
            case GameManager.GameState.INIT:
            OnInit();
            break;
            case GameManager.GameState.PLAY:
            OnPlay();
            break;
            case GameManager.GameState.PAUSE:
            OnPause();
            break;
            case GameManager.GameState.GAMEOVER:
            OnGameOver();
            break;
        }
    }

    void OnTitle() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseEvent.Dispatch();
            return;
        }

        if(Input.anyKeyDown) {
            InitializeEvent.Dispatch();
        }
    }

    void OnInit() {
        if(Input.GetKeyDown(KeyCode.Escape)) return;

        if(Input.anyKeyDown) {
            StartEvent.Dispatch();
        }
    }

    void OnPlay() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseEvent.Dispatch();
            return;
        }

        if(Input.anyKeyDown) {
            player.Jump();
        }
    }

    void OnPause() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameManager.PrevState == GameManager.GameState.TITLE) {
                TitleEvent.Dispatch();
            }
            if(GameManager.PrevState == GameManager.GameState.INIT) {
                InitializeEvent.Dispatch();
            }
            if(GameManager.PrevState == GameManager.GameState.PLAY) {
                ResumeEvent.Dispatch();
            }
        }
    }

    void OnGameOver() {
        if(Input.anyKeyDown) {
            InitializeEvent.Dispatch();
        }
    }
}
