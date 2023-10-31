using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private Progress progress;

    private void Awake() {
        SystemInitialize();
    }

    private void SystemInitialize() {
        Application.runInBackground = true;

        int width = Screen.width;
        int height = (int)(Screen.height / 1.6f);
        Screen.SetResolution(width, height, true);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //progress.Play(OnAfterProgress);
    }

    private void OnAfterProgress( ) {
        
    }
}
