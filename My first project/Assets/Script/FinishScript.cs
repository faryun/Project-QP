using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinishScript : MonoBehaviour
{
    Timer timer;

    private void Awake() 
    {
        timer = GameObject.Find("Time").GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
            timer.end = true;
            if(DataManager.Instance.data.time[DataManager.Instance.data.currentLevel] == 0 || timer.currentTime < DataManager.Instance.data.time[DataManager.Instance.data.currentLevel]) {
                DataManager.Instance.data.time[DataManager.Instance.data.currentLevel] = timer.currentTime;
                DataManager.Instance.SaveGameData();
            }
            DataManager.Instance.data.isUnlock[DataManager.Instance.data.currentLevel + 1] = true;
            DataManager.Instance.SaveGameData();
            SoundManager.instance.PlaySound("Lever");
            SceneManager.LoadScene("LevelSelect");
    }
}

