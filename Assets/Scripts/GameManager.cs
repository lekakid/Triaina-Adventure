using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Events")]
    [SerializeField] GameEventSO TitleEvent;

    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    public enum GameState { TITLE, INIT, PLAY, PAUSE, GAMEOVER }
    public static GameState State { get; private set; }
    public static GameState PrevState { get; private set; }

    void Start() {
        TitleEvent.Dispatch();
    }

    void SetState(GameState nextState) {
        PrevState = State;
        State = nextState;
    }

    public void Initialize() {
        Time.timeScale = 1f;
        SetState(GameState.INIT);
        ScoreManager.ResetScore();
    }

    public void GameStart() {
        SetState(GameState.PLAY);
    }

    public void Pause() {
        Time.timeScale = 0f;
        SetState(GameState.PAUSE);
    }

    public void Resume() {
        Time.timeScale = 1f;
        SetState(GameState.PLAY);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        SetState(GameState.GAMEOVER);
        ScoreManager.SaveHighScore();
    }

    public void Quit() {
        Application.Quit();
    }
}
