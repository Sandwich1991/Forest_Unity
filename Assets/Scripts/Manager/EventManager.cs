using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager
{
    private Camera _camera;
    private Animator _animator;
    private RuntimeAnimatorController _animController;

    // 이벤트 발생 시 카메라 애니메이션을 실행할 서브 카메라를 만듦
    void MakeSubCamera(string animation)
    {
        _camera = new GameObject{ name = "@SubCamera" }.AddComponent<Camera>();
        _camera.AddComponent<EventCloser>();
        _animator = _camera.AddComponent<Animator>();
        
        _animController =
            Managers.Resource.Load<RuntimeAnimatorController>("Art/Animation/Animator/CameraAnimController");
        _animator.runtimeAnimatorController = _animController;
        _animator.Play(animation);
    }

    // 서브카메라를 없앰
    void ClearSubCamera()
    {
        _camera = null;
        _animator = null;
        _animController = null;
        Managers.Resource.Destroy("@SubCamera");
    }
    
    // 카메라 애니메이션이 실행되는 이벤트
    public void CameraEventOn(string animation)
    {
        Managers.UI.MainUIOff();
        Managers.UI.CinemaSceneOn();
        Managers.Input.InputOn = false;
        MakeSubCamera(animation);
    }

    public void CameraEventOff()
    {
        ClearSubCamera();
        Managers.UI.MainUIOn();
        Managers.UI.CinemaSceneOff();
        Managers.Input.InputOn = true;
    }
    
}
