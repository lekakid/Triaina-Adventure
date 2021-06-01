using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {
    [Header("Game Object")]
	[SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI BestScoreText;

    [Header("Scriptable Object")]
    [SerializeField] ScoreManager ScoreManager;
    [SerializeField] GameEventSO InputUnlockEvent;
    [Space]
    [SerializeField] TMP_ColorGradient GoldGradient;
    [SerializeField] TMP_ColorGradient SilverGradient;
    [SerializeField] TMP_ColorGradient BronzeGradient;
    [SerializeField] Material GoldOutline;
    [SerializeField] Material SilverOutline;
    [SerializeField] Material BronzeOutline;

    public void SetResult() {
        Gold.SetActive(false);
        Silver.SetActive(false);
        Bronze.SetActive(false);

        int score = ScoreManager.Score;
        int bestScore = ScoreManager.HighScore;

        ScoreText.text = $"{score:0000}";
        BestScoreText.text = $"{bestScore:0000}";

        if(score >= GameManager.GoldScore) {
            Gold.SetActive(true);
            ScoreText.colorGradientPreset = GoldGradient;
            ScoreText.fontMaterial = GoldOutline;
        }
        else if(score >= GameManager.SilverScore) {
            Silver.SetActive(true);
            ScoreText.colorGradientPreset = SilverGradient;
            ScoreText.fontMaterial = SilverOutline;
        }
        else if(score >= GameManager.BronzeScore) {
            Bronze.SetActive(true);
            ScoreText.colorGradientPreset = BronzeGradient;
            ScoreText.fontMaterial = BronzeOutline;
        }

        if(bestScore >= GameManager.GoldScore) {
            BestScoreText.colorGradientPreset = GoldGradient;
            BestScoreText.fontMaterial = GoldOutline;
        }
        else if(bestScore >= GameManager.SilverScore) {
            BestScoreText.colorGradientPreset = SilverGradient;
            BestScoreText.fontMaterial = SilverOutline;
        }
        else if(bestScore >= GameManager.BronzeScore) {
            BestScoreText.colorGradientPreset = BronzeGradient;
            BestScoreText.fontMaterial = BronzeOutline;
        }
    }

    public void UnlockInput() {
        InputUnlockEvent.Dispatch();
    }
}
