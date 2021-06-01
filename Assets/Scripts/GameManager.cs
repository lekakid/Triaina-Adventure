using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Settings")]
    [SerializeField] int _endingScore = 100;
    public static int EndingScore;
    [SerializeField] int _goldScore = 100;
    public static int GoldScore;
    [SerializeField] int _silverScore = 70;
    public static int SilverScore;
    [SerializeField] int _bronzeScore = 30;
    public static int BronzeScore;

    [Header("Events")]
    [SerializeField] GameEventSO TitleEvent;

    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    public enum GameState { TITLE, INIT, PLAY, PAUSE, GAMEOVER }
    public static GameState State { get; private set; }
    public static GameState PrevState { get; private set; }

    void Awake() {
        EndingScore = _endingScore;
        GoldScore = _goldScore;
        SilverScore = _silverScore;
        BronzeScore = _bronzeScore;
    }

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

    public void Title() {
        Time.timeScale = 1f;
        SetState(GameState.TITLE);
    }

    public void GameStart() {
        Time.timeScale = 1f;
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
