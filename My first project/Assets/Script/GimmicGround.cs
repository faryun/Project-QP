using System;
using System.Collections;
using System.Collections.Generic;
using ObjectState;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.PlasticSCM.Editor.WebApi;
using GroundState;

namespace GroundState
{
    //오브젝트 분류
    public enum GroundType
    {
        test,
    }
}

public class GimmicGround : MonoBehaviour
{
    private PlayerManager player;
    public GroundType groundType;
    Timer timer;

    private void Awake() {
        timer = GameObject.Find("Time").GetComponent<Timer>();
    }

    public void GroundEffect() 
    {
        if(groundType == GroundType.test) {
            Debug.Log("느려진다.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collison) 
    {
        //플레이어 감지
        if(collison.CompareTag("Player"))
        {
            player = collison.gameObject.GetComponent<PlayerManager>();
        }
    }

    private void OnTriggerExit2D(Collider2D collison) 
    {
        if(collison.CompareTag("Player"))
        {
            if(player != null)
            {
                player = null;
            }
        }
    }
}
