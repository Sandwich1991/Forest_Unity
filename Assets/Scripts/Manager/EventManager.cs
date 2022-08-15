using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{
    public Action SceneEnd;
    private GameObject _camera;
    private CameraController _controller;

    public void init()
    {
        _camera = GameObject.Find("Main Camera");
        _controller = _camera.GetComponent<CameraController>();
    }
    

    // 카메라 애니메이션이 실행되는 이벤트
    public void CameraEventOn()
    {
        init();
        _controller._mode = Define.CameraMode.OnEvent;
        Managers.UI.MainUIOff();
        Managers.UI.CinemaSceneOn();
        Managers.Input.InputOn = false;
    }
    
    public void CameraEventOff()
    {
        init();
        _controller._mode = Define.CameraMode.QuarterView;
        Managers.UI.MainUIOn();
        Managers.UI.CinemaSceneOff();
        Managers.Input.InputOn = true;
    }
    
    
}
