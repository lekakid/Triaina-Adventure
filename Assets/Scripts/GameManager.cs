using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Events")]
    [SerializeField] GameEventSO PauseEvent;
    [SerializeField] GameEventSO ResumeEvent;

    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    bool isPause;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPause) {
                Resume();
                ResumeEvent.Dispatch();
            }
            else {
                Pause();
                PauseEvent.Dispatch();
            }
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        isPause = true;
    }

    public void Resume() {
        Time.timeScale = 1f;
        isPause = false;
    }

    public void OnGameOver() {
        ScoreManager.SaveHighScore();
    }
}
