using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private PlayerManager player;

    public void Interaction() 
    {
        //상호작용 관련 함수
        Debug.Log("버섯이다");
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
