using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource bgm_player;
    public AudioSource sfx_player;

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
    }

    //사운드 저장 배열
    public AudioClip[] bgm_audio_clips;
    public AudioClip[] sfx_audio_clips;

    //배경음악 재생
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
    
    //효과음 재생
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
}
