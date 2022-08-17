using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    
    public Define.CameraMode _mode; // 카메라 모드
    public Define.CameraSubject _subject; // 카메라 피사체 열거형
    public GameObject _currentSubject; // 현재 카메라 피사체

    private GameObject _player;
    private GameObject _npc;

    /**********************************************************************/
    // Methods

    public void GetSubject()
    {
        switch (_subject)
        {
            case Define.CameraSubject.Player:
                _currentSubject = _player;
                break;
            
            case Define.CameraSubject.NPC:
                _currentSubject = _npc;
                break;
        }
    }

    void SetQuarterView()
    {
        GetSubject();
        Vector3 deltaPos = new Vector3(0f, 8f, -4f);
        
        transform.position = _currentSubject.transform.position + deltaPos;
        transform.LookAt(_currentSubject.transform);
    }
    
    void SetTopView()
    {
        GetSubject();
        Vector3 deltaPos = new Vector3(0f, 6f, 0f);
        Vector3 deltaRot = new Vector3(90f, 0f, 0f);
        
        transform.position = _currentSubject.transform.position + deltaPos;
        transform.rotation = Quaternion.Euler(deltaRot);
    }

    void OnEvent() { }

    // 카메라 모드 전환 메소드
    public Define.CameraMode CamSwich()
    {
        if (_mode == Define.CameraMode.QuarterView)
            _mode = Define.CameraMode.TopView;
        else
            _mode = Define.CameraMode.QuarterView;

        return _mode;
    }

    // 애니메이션 이벤트 종료
    public void SceneEnd()
    {
        Managers.Event.EventState.Invoke(Define.AnimationEvent.Null);
    }
    
    /**********************************************************************/
    // Game System
    
    void Start()
    {
        _subject = Define.CameraSubject.Player;
        _mode = Define.CameraMode.QuarterView;
        
        _player = GameObject.Find("Player");
        _npc = GameObject.Find("NPC");
    }
    
    void LateUpdate()
    {
        switch (_mode)
        {
            case Define.CameraMode.OnEvent:
                OnEvent();
                break;
                
            case Define.CameraMode.QuarterView:
                SetQuarterView();
                break;
            
            case Define.CameraMode.TopView:
                SetTopView();
                break;
        }
    }
}
