using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private string destinationScene;
    [SerializeField]
    private int level;
    [SerializeField]
    private TextMeshProUGUI record;
    [SerializeField]
    private Button nextLevelButton;

    private void Awake() {
        DataManager.Instance.LoadGameData();
        DataManager.Instance.data.isUnlock[0] = true;
    }
    private void Start() {
        record.text = (DataManager.Instance.data.time[level] == 0) ? "(not clear)" : $"clear!\n {DataManager.Instance.data.time[level]:F2}sec";
        // 현재 레벨이 마지막 레벨(7)이 아니고, 다음 레벨이 잠금 해제되었다면 버튼을 활성화
        if (level < 7) nextLevelButton.interactable = DataManager.Instance.data.isUnlock[level + 1];
        
        // 마지막 레벨인 경우 버튼을 비활성화
        else nextLevelButton.interactable = false;
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
