using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    /**********************************************************************/
    // Methods
    
    // 경로를 이용하여 에셋을 로드하는 메소드
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int idx = name.LastIndexOf('/');
            if (idx >= 0) // idx가 존재한다면
                name = name.Substring(idx + 1); // name은 문자 '/'이후
        }
        return Resources.Load<T>(path);
    }

    // 프리팹 복제를 위한 메소드
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Faild to Load prefab : {path}");
            return null;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }
    
    // 오브젝트를 삭제하기 위한 메소드
    public void Destroy(string objectName, float time = 0)
    {
        GameObject go = GameObject.Find(objectName);
        
        if (go == null)
            return;
        Object.Destroy(go, time);
    }
}
