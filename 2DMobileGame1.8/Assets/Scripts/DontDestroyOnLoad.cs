using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject DontDestroyWhenLoading;
    public GameObject MainCamera;
    public GameObject platform;
    public GameObject _SCRIPTS_;
    public GameObject DragLine;
    public GameObject Canvas;
    public GameObject EventSystem;
    public GameObject DeathTrigger;

    void Update()
    {
        DontDestroyOnLoad(DontDestroyWhenLoading);
        DontDestroyOnLoad(MainCamera);
        DontDestroyOnLoad(platform);
        DontDestroyOnLoad(_SCRIPTS_);
        DontDestroyOnLoad(DragLine);
        DontDestroyOnLoad(Canvas);
        DontDestroyOnLoad(EventSystem);
        DontDestroyOnLoad(DeathTrigger);
    }
}
