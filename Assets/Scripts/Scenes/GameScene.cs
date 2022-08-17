using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Clear()
    {
        
    }
    
    protected override void init()
    {
        base.init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowMainUI();
        Managers.UI.SetWorldSpaceCanvas();
        Managers.Input.KeyAction += SwitchGameState;
    }
}
