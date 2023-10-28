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

    public void Play(UnityAction action=null) {
        StartCoroutine(OnProgress(action));
    }

    private IEnumerator OnProgress(UnityAction action) {
        float current = 0;
        float progress = 0;
        int buttonAlpha = 0;

        while (progress < 1)
        {
            current += Time.deltaTime * 0.5f;
            progress = current / progressTime;

            textProgressData.text = $"·ÎµùÁß.. {sliderProgress.value * 100:F0}%";
            sliderProgress.value = Mathf.Lerp(0, 1, progress);

            yield return null;  
        }

        startButton.gameObject.SetActive(true);

        action?.Invoke();
    }
}
