using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextAsset = UnityEngine.TextCore.Text.TextAsset;

public class CameraSwitch : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;
    }

    public void CamModeSwich()
    {
        CameraController controller = _camera.GetComponent<CameraController>();
        
        Define.CameraMode camMode = controller.CamSwich();

        if (camMode == Define.CameraMode.QuarterView)
            gameObject.GetComponentInChildren<Text>().text = "Quater View";
        else
            gameObject.GetComponentInChildren<Text>().text = "Top View";
    }
}
