using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePresenter : MonoBehaviour {
    [SerializeField] ScoreManager ScoreManager;
	[SerializeField] TextMeshProUGUI ScoreText;
    [Space]
    [SerializeField] TMP_ColorGradient GoldGradient;
    [SerializeField] TMP_ColorGradient SilverGradient;
    [SerializeField] TMP_ColorGradient BronzeGradient;
    [SerializeField] Material GoldOutline;
    [SerializeField] Material SilverOutline;
    [SerializeField] Material BronzeOutline;

    void Awake() {
        ScoreManager.AddScoreListener(SetScoreText);
    }

    public void SetScoreText() {
        int score = ScoreManager.Score;

        ScoreText.text = $"{score:0000}";

        if(score >= GameManager.GoldScore) {
            ScoreText.colorGradientPreset = GoldGradient;
            ScoreText.fontMaterial = GoldOutline;
        }
        else if(score >= GameManager.SilverScore) {
            ScoreText.colorGradientPreset = SilverGradient;
            ScoreText.fontMaterial = SilverOutline;
        }
        else if(score >= GameManager.BronzeScore) {
            ScoreText.colorGradientPreset = BronzeGradient;
            ScoreText.fontMaterial = BronzeOutline;
        }
    }
}
