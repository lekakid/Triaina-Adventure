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

    [Header("Data Container")]
	[SerializeField] ScoreManager ScoreManager;

    void Awake() {
        EndingScore = _endingScore;
        GoldScore = _goldScore;
        SilverScore = _silverScore;
        BronzeScore = _bronzeScore;
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
