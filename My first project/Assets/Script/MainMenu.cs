using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject optionUI;

    public void Play()
    {
        SoundManager.instance.PlaySound("Click");
        SceneManager.LoadScene("LevelSelect");
    }

    public void OptionUI()
    {
        SoundManager.instance.PlaySound("Click");
        menuUI.SetActive(false);
        optionUI.SetActive(true);
    }

    public void MenuUI()
    {
        SoundManager.instance.PlaySound("Click");
        menuUI.SetActive(true);
        optionUI.SetActive(false);
    }

    public void Exit()
    {
        SoundManager.instance.PlaySound("Click");
        Debug.Log("게임 나가기 성공");
        Application.Quit();
    }
}

