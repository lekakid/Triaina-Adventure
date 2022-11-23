using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private const string EZ_MODE = "EzMode";
    private const string DISABLE_SKIN = "DISABLE_SPECIAL_SKIN";

    [Header("Settings")]
    [SerializeField] int _endingScore = 100;
    public static int EndingScore;
    [SerializeField] int _goldScore = 100;
    public static int GoldScore;
    [SerializeField] int _silverScore = 70;
    public static int SilverScore;
    [SerializeField] int _bronzeScore = 30;
    public static int BronzeScore;
    [SerializeField] int _achievementScore = 150;
    public static int AchievementScore;

    public static bool EzMode {
        get {
            return PlayerPrefs.GetInt(EZ_MODE, 0) == 1;
        }
        set {
            PlayerPrefs.SetInt(EZ_MODE, value ? 1 : 0);
            ScoreManager.LoadScore();
        }
    }

    public static bool achieveGoal {
        get {
            return ScoreManager.AchievementScore >= AchievementScore;
        }
    }

    public static bool disableSpecialSkin {
        get {
            return PlayerPrefs.GetInt(DISABLE_SKIN, 0) == 1;
        }
        set {
            PlayerPrefs.SetInt(DISABLE_SKIN, value ? 1 : 0);
        }
    }

    public static bool isSpecial {
        get {
            return achieveGoal && !disableSpecialSkin;
        }
    }

    [Header("Data Container")]
    public static ScoreManager ScoreManager;
	[SerializeField] ScoreManager _scoreManager;

    void Awake() {
        EndingScore = _endingScore;
        GoldScore = _goldScore;
        SilverScore = _silverScore;
        BronzeScore = _bronzeScore;
        AchievementScore = _achievementScore;

        ScoreManager = _scoreManager;
    }

    public void Pause() {
        Time.timeScale = 0f;
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    public void Quit() {
        Application.Quit();
    }
}
