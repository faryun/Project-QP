using System;
using System.Collections;
using System.Collections.Generic;
using ObjectState;
using UnityEngine;
using UnityEngine.UI;

namespace ObjectState
{
    //오브젝트 분류
    public enum ObjectType
    {
        etest,
        etest1,
        hidden,
    }
}

public class InteractionObject : MonoBehaviour
{
    private PlayerManager player;
    public ObjectType objectType;
    public GameObject Object;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public void Interaction() 
    {
        //상호작용 관련
        if(objectType == ObjectType.etest)
        {
            Debug.Log("버섯이다.");
        }

        if(objectType == ObjectType.etest1)
        {
            Debug.Log("끝이다.");
        }

        if(objectType == ObjectType.hidden)
        {
            Debug.Log("무언가가 작동한거 같다.");
            spriteRenderer.sprite = sprite; //img change
            Object.SetActive(true);
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
