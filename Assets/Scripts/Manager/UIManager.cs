using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIManager
{
    /**********************************************************************/
    // Fields
    private GameObject _mainUI;
    private GameObject _root;
    private GameObject _barrier;
    
    /**********************************************************************/
    // Methods
    
    // 하이어라키에 @UI_Root 오브젝트를 찾아보고
    // 없으며 추가하는 메소드
    public void init()
    {
        _root = GameObject.Find("@UI_Root");
        if (_root == null)
            _root = new GameObject { name = "@UI_Root" };
        Object.DontDestroyOnLoad(_root);
        
    }
    
    // 화면에 메인 UI를 띄우는 메소드
    public void ShowMainUI()
    {
        if (_mainUI == null)
            _mainUI = Managers.Resource.Instantiate("UI/MainUI/MainUI", _root.transform);
        else
            return;
    }
    
    // 월드 스페이스 캔버스 생성
    public GameObject SetWorldSpaceCanvas()
    {
        GameObject go = GameObject.Find("@WorldSpaceCanvas");
        if (go == null)
        {
            go = new GameObject { name = "@WorldSpaceCanvas" };
            Canvas canvas = go.AddComponent<Canvas>();
            go.AddComponent<CanvasScaler>();
            go.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;
        }
        return go;
    }
    
    // 메인 UI 켜기
    public void MainUIOn()
    {
        if (_mainUI == null)
            ShowMainUI();
        Transform[] chidren = Utill.FindChidren(_mainUI);
        foreach (Transform ui in chidren)
        {
            ui.gameObject.SetActive(true);
        }
    }
    
    // 메인 UI 끄기
    public void MainUIOff()
    {
        if (_mainUI == null)
            return;
        GameObject[] uis = GameObject.FindGameObjectsWithTag("MainUI");
        foreach (GameObject ui in uis)
        {
            ui.gameObject.SetActive(false);
        }
    }

    // 씨네마 씬 켜기
    public void CinemaSceneOn()
    {
        if (_barrier == null)
            _barrier = Managers.Resource.Instantiate("UI/SceneBarrier", _mainUI.transform);
        _barrier.SetActive(true);
    }
    
    // 씨네마 씬 끄기
    public void CinemaSceneOff()
    {
        _barrier = _mainUI.transform.Find("SceneBarrier").gameObject;
        if (_barrier == null)
            return;
        Managers.Resource.Destroy(_barrier.name);
    }
    
}
