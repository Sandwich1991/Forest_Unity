using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = System.Object;

// 씬 로드를 위한 추상 클래스
public abstract class BaseScene : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    
    // 씬 타입을 enum에서 가져올 프로퍼티
    public static Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;
    
    public bool _isGameRunning = true;
    
    /**********************************************************************/
    // Methods

    protected virtual void init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
    }
    
    // 씬에서 사용중인 리소스를 클리어하기 위한 메소드
    public abstract void Clear();
    
    
    public void SwitchGameState()
    {
        if (_isGameRunning == true && Input.GetKeyDown(KeyCode.Escape)) // 게임이 진행중인 상태에서 ESC를 누르면
            PauseGame();
        else if (_isGameRunning == false && Input.GetKeyDown(KeyCode.Escape)) // 게임이 멈춘 상황에서 다시 ESC를 누르면
            RunGame();
    }
    
    public void RunGame()
    {
        if (_isGameRunning == true)
            return;
        
        _isGameRunning = true;
        Managers.Sound.UnMute();
        Time.timeScale = 1;
        GameObject puaseScreen = GameObject.Find("GamePauseScreen");
        Destroy(puaseScreen);
    }

    public void PauseGame()
    {
        if (_isGameRunning == false)
            return;
        
        _isGameRunning = false;
        Managers.Sound.Mute();
        Time.timeScale = 0;
        GameObject uiRoot = GameObject.Find("@UI_Root");
        
        if (uiRoot == null)
        {
            print("UI_Root is Missing!");
            return;
        }

        GameObject mainUI = uiRoot.transform.Find("MainUI").gameObject;
        Managers.Resource.Instantiate("UI/MainUI/GamePauseScreen", mainUI.transform);
    }

    /**********************************************************************/
    // Game System

    private void Awake()
    {
        init();
    }
}
