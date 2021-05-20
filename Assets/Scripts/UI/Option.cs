using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {
	[Header("Components")]
    public Slider BGMSlider;
    public Slider SFXSlider;

    [Header("Events")]
    public GameEventSO InitializeEvent;
    public GameEventSO ResumeEvent;

    [Header("Objects")]
    public SoundManager SoundManager;

    void Start() {
        BGMSlider.value = Mathf.Max(SoundManager.BGMVolume, BGMSlider.minValue);
        SFXSlider.value = Mathf.Max(SoundManager.SFXVolume, SFXSlider.minValue);
    }

    public void ClickOnResume() {
        if(GameManager.PrevState == GameManager.GameState.INIT) {
            InitializeEvent.Dispatch();
        }
        if(GameManager.PrevState == GameManager.GameState.PLAY) {
            ResumeEvent.Dispatch();
        }
    }
}
