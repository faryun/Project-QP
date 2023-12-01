using System;
using System.Collections;
using System.Collections.Generic;
using ObjectState;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.PlasticSCM.Editor.WebApi;

namespace ObjectState
{
    //오브젝트 분류
    public enum ObjectType
    {
        lever,
        finish,
    }
}

public class InteractionObject : MonoBehaviour
{
    private PlayerManager player;
    public ObjectType objectType;
    public GameObject Object;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    private bool trigger = false;
    public AudioSource interactionSound;
    Timer timer;

    private void Awake() {
        timer = GameObject.Find("Time").GetComponent<Timer>();
    }

    public void Interaction() 
    {
        //상호작용 관련
        if(objectType == ObjectType.finish) {
            timer.end = true;
            if(DataManager.Instance.data.time[DataManager.Instance.data.currentLevel] == 0 || timer.currentTime < DataManager.Instance.data.time[DataManager.Instance.data.currentLevel]) {
                DataManager.Instance.data.time[DataManager.Instance.data.currentLevel] = timer.currentTime;
                DataManager.Instance.SaveGameData();
            }
            DataManager.Instance.data.isUnlock[DataManager.Instance.data.currentLevel + 1] = true;
            DataManager.Instance.SaveGameData();
            Debug.Log("끝이다.");
            SoundManager.instance.PlaySound("Lever");
            SceneManager.LoadScene("LevelSelect");
        }

        if(objectType == ObjectType.lever)
        {    
            if(!trigger)
            {
                Debug.Log("무언가가 작동한거 같다.");
                SoundManager.instance.PlaySound("Lever");
                spriteRenderer.sprite = sprite; //img change
                Object.SetActive(true);
                trigger = true;
            }

            else return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collison) 
    {
        //플레이어 감지
        if(collison.CompareTag("Player"))
        {
            player = collison.gameObject.GetComponent<PlayerManager>();

            if(player != null)
            {
                player.interObj = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collison) 
    {
        if(collison.CompareTag("Player"))
        {
            if(player != null)
            {
                player.interObj = null;
                player = null;
            }
        }
    }
}
