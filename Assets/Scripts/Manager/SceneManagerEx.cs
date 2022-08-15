using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    // BaseScene을 상속받는 컴포넌트를 가진 씬을 반환하는 프로퍼티
    // (씬은 enum으로 관리되기 때문에 현재 실행중인 씬을 반환한다)
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    // Define에서 정의된 씬의 이름을 가져오는 메소드
    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }
    
    // 씬을 클리어하기 위한 메소드
    public void Clear()
    {
        CurrentScene.Clear();
    }
}
