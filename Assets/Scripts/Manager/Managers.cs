using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    static Managers m_instance;
    public static Managers Instance { get { init(); return m_instance; }}
    /**********************************************************************/
    // Core
    // 매니져들을 호출
    private InputManager _input = new InputManager();
    private SoundManager _sound = new SoundManager();
    private ResourceManager _resource = new ResourceManager();
    private UIManager _ui = new UIManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private EventManager _event = new EventManager();
    
    
    /**********************************************************************/
    // Properties
    // 다른 컴포넌트에서 매니져들을 호출하기 위한 프로퍼티
    public static InputManager Input { get; } = Instance._input;
    public static SoundManager Sound { get; } = Instance._sound;
    public static ResourceManager Resource { get; } = Instance._resource;
    public static UIManager UI { get; } = Instance._ui;
    public static SceneManagerEx Scene { get; } = Instance._scene;
    public static EventManager Event { get; } = Instance._event;


    /**********************************************************************/
    // Methods
    
    // 매니져 게임 오브젝트를 만들기 위한 메소드
    public static void init()
    {
        if (m_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
                
                DontDestroyOnLoad(go);
                m_instance = go.GetComponent<Managers>();
                
                // 코어 매니져의 init 메소드 실행
                m_instance._sound.init();
                m_instance._ui.init();
                m_instance._event.init();
            }
        }
    }
    
    // 매니져들의 리소스를 Clear하기 위한 메소드
    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
    }
    /**********************************************************************/
    // Game System
    void Start()
    {
        init();
    }

    
    void Update()
    {
        _input.OnUpdate();
    }
}
