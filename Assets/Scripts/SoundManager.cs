using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] AudioClip[] BGMList;
    [SerializeField] AudioClip[] SFXList;

	AudioSource bgmSource;
    AudioSource sfxSource;

    Dictionary<string, AudioClip> bgmDic;
    Dictionary<string, AudioClip> sfxDic;

    public float BGMVolume {
        get { return bgmSource.volume; } 
        set { bgmSource.volume = value; }
    }
    public float SFXVolume {
        get { return sfxSource.volume; } 
        set { sfxSource.volume = value; } 
    }

    void Awake() {
        bgmSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        bgmSource.volume = PlayerPrefs.GetFloat("BGM Volume", 0.5f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFX Volume", 0.5f);

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
            bgmSource.clip = clip;
            bgmSource.Play();
        }
    }

    public void StopBGM(){
        bgmSource.clip = null;
        bgmSource.Stop();
    }

    public void PlaySFX(string name) {
        AudioClip clip;
        if(sfxDic.TryGetValue(name, out clip)) {
            sfxSource.PlayOneShot(clip);
        }
    }
}
