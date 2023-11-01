using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume(){
        Debug.Log("재시작");
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        Debug.Log("일시정지");
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToSettingMenu(){
        Debug.Log("아직 미구현입니다...");
    }

    public void ToLevelSelect(){
        Debug.Log("레벨 선택 이동");
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame(){
        Debug.Log("게임 나가기 성공");
        Application.Quit();
    }
}