using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    public enum GameState { INIT, PLAY, PAUSE, GAMEOVER }
    public static GameState State { get; private set; }

    public void Initialize() {
        Time.timeScale = 1f;
        State = GameState.INIT;
        ScoreManager.ResetScore();
    }

    public void GameStart() {
        State = GameState.PLAY;
    }

    public void Pause() {
        Time.timeScale = 0f;
        State = GameState.PAUSE;
    }

    public void Resume() {
        Time.timeScale = 1f;
        State = GameState.PLAY;
    }

    public void GameOver() {
        Time.timeScale = 0f;
        State = GameState.GAMEOVER;
        ScoreManager.SaveHighScore();
    }
}
