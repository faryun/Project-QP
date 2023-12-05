using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public Slider bgm_slider;
    public Slider sfx_slider;

    private void Start()
    {
        // 저장된 슬라이더 값이 있다면 불러오기
        LoadSliderValue();
    }
    
    public void ChangeBGMSound()
    {
        float volume = bgm_slider.value;

        if(volume == -40f) MasterMixer.SetFloat("BGM", -80);
        else MasterMixer.SetFloat("BGM", volume);

        // 슬라이더 값 저장
        PlayerPrefs.SetFloat("BGMSlider", bgm_slider.value);
    }

    public void ChangeSFXSound()
    {
        float volume = sfx_slider.value;

        if(volume == -40f) MasterMixer.SetFloat("SFX", -80);
        else MasterMixer.SetFloat("SFX", volume);

        // 슬라이더 값 저장
        PlayerPrefs.SetFloat("SFXSlider", sfx_slider.value);
    }

    // 저장된 슬라이더 값을 불러오기
    public void LoadSliderValue()
    {
        if(PlayerPrefs.HasKey("BGMSlider"))
        {
            bgm_slider.value = PlayerPrefs.GetFloat("BGMSlider");
        }

        if(PlayerPrefs.HasKey("SFXSlider"))
        {
            sfx_slider.value = PlayerPrefs.GetFloat("SFXSlider");
        }
    }
}
