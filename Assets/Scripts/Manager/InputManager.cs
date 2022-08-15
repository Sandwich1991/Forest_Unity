using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    /**********************************************************************/
    // Fields
    
    // 마우스 이벤트와 키보드 이벤트를 콜백으로 받음
    public Action<Define.MouseEvent> MouseAction = null;
    public Action KeyAction = null;

    // 마우스 클릭과 누르는 상태를 구분
    private bool _pressed = false;
    private bool _inputOn = true;
    
    // 인풋을 켜고 끄기 위한 프로퍼티
    public  bool InputOn
    {
        get { return _inputOn; }
        set { _inputOn = value; }
    }
    
    /**********************************************************************/
    // Methods
    
    // 이벤트 콜백을 받아 Invoke를 하기 위한 메소드
    public void OnUpdate()
    {
        if (InputOn)
        {
            
            
            if (Input.anyKey && KeyAction != null)
                KeyAction.Invoke();
            
            if (Input.GetMouseButton(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()) // UI 클릭시 이동 방지
                    return;
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;

            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
