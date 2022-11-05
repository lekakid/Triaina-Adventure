using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "Project/ScoreManager")]
public class ScoreManager : ScriptableObject {
	public int Score { get; private set; }
    public int HighScore { get; private set; }
    public int TotalScore { get; private set; }
    public int AchievementScore {
        get {
            return PlayerPrefs.GetInt(TOTAL_SCORE, 0);
        }
    }

    private const string HIGH_SCORE = "HighScore";
    private const string TOTAL_SCORE = "TotalScore";
    private const string EZ = "_ez";

    UnityEvent OnScoreChange = new UnityEvent();

    void OnEnable() {
        LoadScore();
    }

    void OnDisable() {
        Score = 0;
        HighScore = 0;
    }

    public void LoadScore() {
        HighScore = PlayerPrefs.GetInt($"{HIGH_SCORE}{(GameManager.EzMode ? EZ : "")}", 0);
        TotalScore = PlayerPrefs.GetInt($"{TOTAL_SCORE}{(GameManager.EzMode ? EZ : "")}", 0);

        OnScoreChange.Invoke();
    }

    public void AddScore() {
        Score += 1;
        TotalScore += 1;
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
        PlayerPrefs.SetInt($"{HIGH_SCORE}{(GameManager.EzMode ? EZ : "")}", HighScore);
        PlayerPrefs.SetInt($"{TOTAL_SCORE}{(GameManager.EzMode ? EZ : "")}", TotalScore);
    }

    public void AddScoreListener(UnityAction listener) {
        OnScoreChange.AddListener(listener);
    }
}
