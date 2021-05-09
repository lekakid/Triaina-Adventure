using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "Project/ScoreManager")]
public class ScoreManager : ScriptableObject {
	public int Score { get; private set; }
    public int HighScore { get; private set; }

    void Awake() {
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
    }

    public void ResetScore() {
        Score = 0;
    }

    public void SaveHighScore() {
        PlayerPrefs.SetInt("HighScore", HighScore);
    }
}
