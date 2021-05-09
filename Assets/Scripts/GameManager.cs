using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Events")]
    [SerializeField] GameEventSO PauseEvent;
    [SerializeField] GameEventSO ResumeEvent;
    [SerializeField] GameEventSO ChangeScoreEvent;

    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    enum GameState { INIT, PLAY, PAUSE, GAMEOVER }
    GameState State;

    void Start() {
        Time.timeScale = 0f;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(State == GameState.PAUSE) {
                Resume();
            }
            else if(State == GameState.PLAY) {
                Pause();
            }
        }
    }

    public void GameStart() {
        Time.timeScale = 1f;
        State = GameState.PLAY;
        ScoreManager.ResetScore();
        ChangeScoreEvent.Dispatch();
    }

    public void Pause() {
        Time.timeScale = 0f;
        State = GameState.PAUSE;
        PauseEvent.Dispatch();
    }

    public void Resume() {
        Time.timeScale = 1f;
        State = GameState.PLAY;
        ResumeEvent.Dispatch();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        State = GameState.GAMEOVER;
        ScoreManager.SaveHighScore();
    }
}
