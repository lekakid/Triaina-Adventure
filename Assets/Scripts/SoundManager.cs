using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] AudioClip[] BGMList;
    [SerializeField] AudioClip[] SFXList;

	AudioSource bgmSource;
    AudioSource cutSource;
    AudioSource sfxSource;

    Dictionary<string, AudioClip> bgmDic;
    Dictionary<string, AudioClip> sfxDic;

    public float BGMVolume {
        get { return bgmSource.volume; } 
        set {
            bgmSource.volume = value;
            cutSource.volume = value;
        }
    }
    public float SFXVolume {
        get { return sfxSource.volume; } 
        set { sfxSource.volume = value; } 
    }

    void Awake() {
        bgmSource = gameObject.AddComponent<AudioSource>();
        cutSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        bgmSource.volume = PlayerPrefs.GetFloat("BGM Volume", 0.5f);
        cutSource.volume = PlayerPrefs.GetFloat("BGM Volume", 0.5f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFX Volume", 0.5f);

        bgmSource.loop = true;
        cutSource.loop = true;

        bgmDic = new Dictionary<string, AudioClip>();
        foreach(AudioClip a in BGMList) {
            bgmDic.Add(a.name, a);
        }
        sfxDic = new Dictionary<string, AudioClip>();
        foreach(AudioClip a in SFXList) {
            sfxDic.Add(a.name, a);
        }
    }

    void OnApplicationQuit() {
        PlayerPrefs.SetFloat("BGM Volume", BGMVolume);
        PlayerPrefs.SetFloat("SFX Volume", SFXVolume);
    }

    public void PlayBGM(string name) {
        AudioClip clip;
        if(bgmDic.TryGetValue(name, out clip)) {
            if(bgmSource.clip == clip) {
                if(bgmSource.isPlaying) return;

                bgmSource.UnPause();
                return;
            }
            
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void PlayCutBGM(string name) {
        AudioClip clip;
        if(bgmDic.TryGetValue(name, out clip)) {
            if(cutSource.clip == clip) {
                if(cutSource.isPlaying) return;

                cutSource.UnPause();
                return;
            }
            
            cutSource.clip = clip;
            cutSource.Play();
        }
    }

    public void PauseBGM() {
        bgmSource.Pause();
    }

    public void ResumeBGM() {
        bgmSource.UnPause();
    }

    public void StopBGM(){
        bgmSource.clip = null;
        bgmSource.Stop();
    }

    public void StopCutBGM() {
        cutSource.clip = null;
        cutSource.Stop();
    }

    public void PlaySFX(string name) {
        AudioClip clip;
        if(sfxDic.TryGetValue(name, out clip)) {
            sfxSource.PlayOneShot(clip);
        }
    }
}
