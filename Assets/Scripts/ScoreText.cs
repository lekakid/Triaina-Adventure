using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    [SerializeField] ScoreManager ScoreManager;
	Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void SetScoreText() {
        text.text = string.Format("Score: {0:000}", ScoreManager.Score);
    }
}
