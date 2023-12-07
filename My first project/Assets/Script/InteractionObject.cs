using System;
using System.Collections;
using System.Collections.Generic;
using ObjectState;
using UnityEngine;


namespace ObjectState
{
    //오브젝트 분류
    public enum ObjectType
    {
        Once,
        Repeat,
    }
}

public class InteractionObject : MonoBehaviour
{
    public static event Action<int, bool> OnInteractionEvent;
    public int objectIndex;
    public bool trigger = false;
    private PlayerManager player;
    public ObjectType objectType;
    public GameObject affectObject;
    public SpriteRenderer spriteRenderer;
    public Sprite onSprite;
    public Sprite offSprite;
    

    public void Interaction() 
    {
        //상호작용 관련
        if(objectType == ObjectType.Once)
        {    
            if(!trigger)
            {
                Debug.Log("무언가가 작동한거 같다.");
                SoundManager.instance.PlaySFX("Lever");
                spriteRenderer.sprite = onSprite; //img change
                affectObject.SetActive(true);
                trigger = true;
                OnInteractionEvent?.Invoke(objectIndex,trigger);
            }

            else return;
        }

        //상호작용 관련
        if(objectType == ObjectType.Repeat)
        {    
            if(!trigger)
            {
                Debug.Log("무언가가 작동한거 같다.");
                SoundManager.instance.PlaySFX("Lever");
                spriteRenderer.sprite = onSprite; //img change
                trigger = true;
                OnInteractionEvent?.Invoke(objectIndex,trigger);
            }

            else if(trigger) {
                Debug.Log("무언가가 작동한거 같다.");
                SoundManager.instance.PlaySFX("Lever");
                spriteRenderer.sprite = offSprite; //img change
                trigger = false;
                OnInteractionEvent?.Invoke(objectIndex,trigger);
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
