using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    AudioSource bgm_player;
    AudioSource sfx_player;
    
    public Slider bgm_slider;
    public Slider sfx_slider;
    public static SoundManager instance = null;

    void Awake()
    {
        //사운드 전체 관리를 위한 싱글톤
         if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        bgm_player = GameObject.Find("BGM Player").GetComponent<AudioSource>();
        sfx_player = GameObject.Find("SFX Player").GetComponent<AudioSource>();

        bgm_slider = bgm_slider.GetComponent<Slider>();
        sfx_slider = sfx_slider.GetComponent<Slider>();

        bgm_slider.onValueChanged.AddListener(ChangeBgmSound);
        sfx_slider.onValueChanged.AddListener(ChangeSfxSound);
    }

    public AudioClip[] bgm_audio_clips;
    public AudioClip[] sfx_audio_clips;

    public void PlayBGM(string type)
    {
        int index = 0;

        switch (type) {
            case "Main": index = 0; break;
            case "Stage": index = 1; break;
        }

        bgm_player.clip = bgm_audio_clips[index];
        bgm_player.Play();
    }
    
    public void PlaySFX(string type)
    {
        int index = 0;

        switch (type) {
            case "Walk": index = 0; break;
            case "Jump": index = 1; break;
            case "Lever": index = 2; break;
            case "Click": index = 3; break;
        }

        sfx_player.clip = sfx_audio_clips[index];
        if(!sfx_player.isPlaying) sfx_player.Play();
    }

    void ChangeBgmSound(float value)
    {
        bgm_player.volume = value;
    }

    void ChangeSfxSound(float value)
    {
        sfx_player.volume = value;
    }
}
