using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {
	[Header("Components")]
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Toggle EzModeToggle;

    public Button EndingButton;

    [Header("Objects")]
    public SoundManager SoundManager;
    public CanvasView View;

    [Header("Dispatcher")]
    public GameEventSO ResetEvent;

    void Start() {
        BGMSlider.value = Mathf.Max(SoundManager.BGMVolume, BGMSlider.minValue);
        SFXSlider.value = Mathf.Max(SoundManager.SFXVolume, SFXSlider.minValue);
        EzModeToggle.SetIsOnWithoutNotify(GameManager.EzMode);
    }

    public void TryUnlockEnding() {
        if(PlayerPrefs.GetInt("EndingVisited", 0) > 0) {
            EndingButton.interactable = true;
        }
    }

    public void OnChangeEzMode(bool value) {
        Confirm.Instance.Show("이 설정을 변경하려면 게임을 재시작합니다.", ConfirmMode);
    }

    public void ConfirmMode() {
        Confirm.Instance.Hide();

        if(!Confirm.Instance.value) {
            EzModeToggle.SetIsOnWithoutNotify(!EzModeToggle.isOn);
            return;
        }
        
        GameManager.EzMode = !GameManager.EzMode;
        View.Hide();
        ResetEvent.Dispatch();
    }

    public void OnClickQuit() {
        Confirm.Instance.Show("게임을 종료하시겠습니까?", ConfirmQuit);
    }

    public void ConfirmQuit() {
        if(!Confirm.Instance.value) {
            Confirm.Instance.Hide();
            return;
        }

        Application.Quit();
    }
}
