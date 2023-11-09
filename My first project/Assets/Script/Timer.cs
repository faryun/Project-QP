using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private TextMeshProUGUI timerUI;

    public bool end = false;

    public float currentTime;
    private void Awake() {
        currentTime = 0f;
    }

    public void FixedUpdate() {
        if(!end) {
            currentTime += Time.deltaTime;
            timerUI.text = $"진행시간: {currentTime:F2}";
        }
    }
}
