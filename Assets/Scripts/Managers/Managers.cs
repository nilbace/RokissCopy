using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers instance {get{Init(); return s_instance;}}
    

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UI_Manager _ui_manager = new UI_Manager();
    SceneManagerEX _Scene = new SceneManagerEX();
    SoundManager _sound = new SoundManager();
    public static InputManager input {get {return instance._input;}}
    public static ResourceManager Resource{get{return instance._resource;}}
    public static UI_Manager UI_Manager{get{return instance._ui_manager;}}
    public static SceneManagerEX Scene{get{return instance._Scene;}}
    public static SoundManager Sound{get{return instance._sound;}}
    
    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init(){
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go==null)
            {
                go = new GameObject{name = "@Managers"};
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
