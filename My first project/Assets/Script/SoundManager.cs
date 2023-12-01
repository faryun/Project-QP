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

    public static SoundManager instance;

    void Awake()
    {
        instance = this;
        bgm_player = GameObject.Find("BGM Player").GetComponent<AudioSource>();
        sfx_player = GameObject.Find("SFX Player").GetComponent<AudioSource>();

        bgm_slider = bgm_slider.GetComponent<Slider>();
        sfx_slider = sfx_slider.GetComponent<Slider>();

        bgm_slider.onValueChanged.AddListener(ChangeBgmSound);
        sfx_slider.onValueChanged.AddListener(ChangeSfxSound);
    }

    public AudioClip[] audio_clips;
    public void PlaySound(string type)
    {
        int index = 0;

        switch (type) {
            case "Walk": index = 0; break;
            case "Jump": index = 1; break;
            case "Lever": index = 2; break;
            case "Click": index = 3; break;
        }

        sfx_player.clip = audio_clips[index];
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
