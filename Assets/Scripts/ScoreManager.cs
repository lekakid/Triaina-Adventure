using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "Project/ScoreManager")]
public class ScoreManager : ScriptableObject {
	public int Score { get; private set; }
    public int HighScore { get; private set; }

    UnityEvent OnScoreChange = new UnityEvent();

    void OnEnable() {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void OnDisable() {
        Score = 0;
        HighScore = 0;
    }

    public void AddScore() {
        Score += 1;
        if(Score > HighScore) {
            HighScore = Score;
        }
        OnScoreChange.Invoke();
    }

    public void ResetScore() {
        Score = 0;
        OnScoreChange.Invoke();
    }

    public void SaveHighScore() {
        PlayerPrefs.SetInt("HighScore", HighScore);
    }

    public void AddScoreListener(UnityAction listener) {
        OnScoreChange.AddListener(listener);
    }
}
