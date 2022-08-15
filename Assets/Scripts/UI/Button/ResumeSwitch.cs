using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeSwitch : MonoBehaviour
{
    private GameObject _scene;
    
    public void Resume()
    {
        _scene = GameObject.Find("@Scene");
        if (_scene == null)
        {
            print("@Scene is Missing!");
            return;
        }

        GameScene controller = _scene.GetComponent<GameScene>();
        controller.RunGame();
    }
}
