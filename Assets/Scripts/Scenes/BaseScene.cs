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

    /**********************************************************************/
    // Game System

    private void Awake()
    {
        init();
    }
}
