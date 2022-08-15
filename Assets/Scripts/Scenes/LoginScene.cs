using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    protected override void init()
    {
        base.init();
        SceneType = Define.Scene.Login;
        Managers.Resource.Instantiate("UI/MainUI/LoginScreen");
        Managers.Input.MouseAction += OnMouse;
        Managers.Sound.Play("Sounds/Bgm/Main", Define.Sound.Bgm);
    }

    public override void Clear()
    {
        
    }

    void OnMouse(Define.MouseEvent evt)
    {
        
    }
}
