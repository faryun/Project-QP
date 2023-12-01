using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Progress : MonoBehaviour {
    [SerializeField]
    private Slider sliderProgress;
    [SerializeField]
    private TextMeshProUGUI textProgressData;
    [SerializeField]
    private float progressTime;
    [SerializeField]
    private Button startButton;

    float current = 0;
    float progress = 0;

    private void FixedUpdate() {

        if(progress < 1) {
            current += Time.deltaTime * 0.5f;
            progress = current / progressTime;

            textProgressData.text = $"Loding : {sliderProgress.value * 100:F0}%";
            sliderProgress.value = Mathf.Lerp(0, 1, progress);
        }  

        else {
            startButton.gameObject.SetActive(true);
        }
    }


}
