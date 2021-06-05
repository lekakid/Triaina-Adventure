using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutScene : MonoBehaviour {
    [HideInInspector] public bool isReplay { get; set; }
    [SerializeField] SoundManager SoundManager;

    [SerializeField] UnityEvent CutStartEvent;
    [SerializeField] UnityEvent CutEndEvent;
    [SerializeField] UnityEvent SceneStartEvent;
    [SerializeField] UnityEvent SceneEndEvent;
    [SerializeField] UnityEvent SceneEndOnReplay;

    public void SetVisit(string type) {
        PlayerPrefs.SetInt($"{type}Visited", 1);
    }

    public void OnCutStart() {
        if(CutStartEvent != null) CutStartEvent.Invoke();
    }

    public void OnCutEnd() {
        if(CutEndEvent != null) CutEndEvent.Invoke();
    }

    public void OnSceneStart() {
        if(SceneStartEvent != null) SceneStartEvent.Invoke();
    }

    public void OnSceneEnd() {
        if(isReplay) {
            if(SceneEndOnReplay != null) SceneEndOnReplay.Invoke();
        }
        else {
            if(SceneEndEvent != null) SceneEndEvent.Invoke();
        }
        isReplay = false;
    }

    public void PlaySFX(string name) {
        SoundManager.PlaySFX(name);
    }

    public void StopCutBGM(float duration) {
        SoundManager.StopCutBGM(duration);
    }
}
