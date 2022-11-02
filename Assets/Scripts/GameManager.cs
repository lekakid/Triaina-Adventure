using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private const string EZ_MODE = "EzMode";

    [Header("Settings")]
    [SerializeField] int _endingScore = 100;
    public static int EndingScore;
    [SerializeField] int _goldScore = 100;
    public static int GoldScore;
    [SerializeField] int _silverScore = 70;
    public static int SilverScore;
    [SerializeField] int _bronzeScore = 30;
    public static int BronzeScore;

    public static bool EzMode {
        get {
            return PlayerPrefs.GetInt(EZ_MODE, 0) == 1;
        }
        set {
            PlayerPrefs.SetInt(EZ_MODE, value ? 1 : 0);
            ScoreManager.LoadScore();
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
