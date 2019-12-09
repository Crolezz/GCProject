using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMode : MonoBehaviour
{
    public GameObject DDOLEndlessMode;
    public static bool thisMode = false;

    void Update()
    {
        DontDestroyOnLoad(DDOLEndlessMode);
    }

    public void ToggleEndless()
    {
        if (thisMode == false)
        {
            thisMode = true;
        }
        else if (thisMode == true)
        {
            thisMode = false;
        }
        Debug.Log(thisMode);
    }
}
