using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SoundManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("LevelSelect");
    }

    public void Option()
    {
        SoundManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("Option");
    }

    public void Back()
    {
        SoundManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        SoundManager.instance.PlaySFX("Click");
        Debug.Log("게임 나가기 성공");
        Application.Quit();
    }
}

