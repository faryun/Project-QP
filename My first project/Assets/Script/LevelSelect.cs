using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private string destinationScene;
    [SerializeField]
    private int level;
    [SerializeField]
    private TextMeshProUGUI record;

    private void Awake() {
        DataManager.Instance.LoadGameData();
        DataManager.Instance.data.isUnlock[0] = true;
    }
    private void Start() {
        record.text = (DataManager.Instance.data.time[level] == 0) ? "(not clear)" : $"clear!\n {DataManager.Instance.data.time[level]:F2}sec";
    }
    public void MovetoLevelselect() {
        SoundManager.instance.PlaySFX("Click");
        SoundManager.instance.PlayBGM("Stage");
        DataManager.Instance.data.currentLevel = level;
        SceneManager.LoadScene(destinationScene);
    }

    public void Back()
    {
        SoundManager.instance.PlaySFX("Click");
        SceneManager.LoadScene("MainMenu");
    }
}
