using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{
    public Action<Define.AnimationEvent> EventState;
    private GameObject _camera;
    private CameraController _controller;

    public void init()
    {
        _camera = GameObject.Find("Main Camera");
        _controller = _camera.GetComponent<CameraController>();
        EventState += CameraEventOn;
    }
    

    // EventState 상태에 따라 실행되는 메소드
    public void CameraEventOn(Define.AnimationEvent evt)
    {
        init();
        
        if (evt == Define.AnimationEvent.Null)
        {
            _controller._mode = Define.CameraMode.QuarterView;
            Managers.UI.MainUIOn();
            Managers.UI.CinemaSceneOff();
            Managers.Input.InputOn = true;
        }

        else
        {
            _controller._mode = Define.CameraMode.OnEvent;
            Managers.UI.MainUIOff();
            Managers.UI.CinemaSceneOn();
            Managers.Input.InputOn = false;
        }
    }
}
