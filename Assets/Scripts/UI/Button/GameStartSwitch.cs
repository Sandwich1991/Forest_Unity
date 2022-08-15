using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSwitch : MonoBehaviour
{
    public void GameStart()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
