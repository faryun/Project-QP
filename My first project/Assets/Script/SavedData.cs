using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SavedData : MonoBehaviour
{
    void Start()
    {
        DataManager.Instance.LoadGameData();
    }

    private void OnApplicationQuit() {
        DataManager.Instance.SaveGameData();
    }

    public void ChapterUnlock(int chapterNum) {
        DataManager.Instance.data.isUnlock[chapterNum] = true;
        DataManager.Instance.SaveGameData();
    }
}
