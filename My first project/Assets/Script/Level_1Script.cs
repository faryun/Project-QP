using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1Script : MonoBehaviour
{
    public GameObject Finish;
    [SerializeField] bool[] leverStatus = new bool[3];
    
    void Start()
    {
        for(int i = 0; i < leverStatus.Length; i++) leverStatus[i] = false;
    }

    void Update()
    {
        if(Finish.activeSelf == false && leverStatus[0] && !leverStatus[1] && leverStatus[2])
        {
            CreateFinish();
        }
    }

    void OnEnable()
    {
        InteractionObject.OnInteractionEvent += UpdateLeverStatus;
    }

    void OnDisable()
    {
        InteractionObject.OnInteractionEvent -= UpdateLeverStatus;
    }

    void UpdateLeverStatus(int index, bool state)
    {
        leverStatus[index] = state;
    }

    void CreateFinish()
    {
        Debug.Log("도착지 생성");
        Finish.SetActive(true);
    }
}
