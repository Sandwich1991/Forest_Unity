using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Utill
{
    // 오브젝트가 컴포넌트를 갖고 있는지 찾아보고
    // 없으면 추가하는 메소드
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static Transform[] FindChidren(GameObject go)
    {
        int idx = 0;
        int count = go.transform.childCount;

        Transform[] _children = new Transform[(count)];

        while (idx <= count - 1)
        {
            _children[idx] = go.transform.GetChild(idx);
            idx++;
        }

        return _children;
    }   
    
    
}
