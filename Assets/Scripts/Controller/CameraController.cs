using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    
    // 카메라 모드
    public Define.CameraMode _mode;
    [SerializeField] private GameObject _player;

    /**********************************************************************/
    // Methods
    
    void SetQuarterView()
    {
        Vector3 deltaPos = new Vector3(0f, 8f, -4f);
        
        transform.position = _player.transform.position + deltaPos;
        transform.LookAt(_player.transform);
    }
    
    void SetTopView()
    {
        Vector3 deltaPos = new Vector3(0f, 6f, 0f);
        Vector3 deltaRot = new Vector3(90f, 0f, 0f);
        
        transform.position = _player.transform.position + deltaPos;
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

    public void SceneEnd()
    {
        Managers.Event.SceneEnd.Invoke();
    }
    
    /**********************************************************************/
    // Game System
    
    void Start()
    {
        _mode = Define.CameraMode.QuarterView;
        _player = GameObject.Find("Player");
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
