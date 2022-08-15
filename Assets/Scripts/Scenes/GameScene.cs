using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public bool _isGameRunning = true;
    protected override void init()
    {
        base.init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowMainUI();
        Managers.UI.SetWorldSpaceCanvas();
        Managers.Input.KeyAction += SwitchGameState;
    }

    public override void Clear()
    {
        
    }

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
}
