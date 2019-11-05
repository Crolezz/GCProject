using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDToggleTutorial : MonoBehaviour
{
    public GameObject DDOLToggleTutorial;
    public static bool tutorialOn = false;

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(DDOLToggleTutorial);  
    }

    public void ToggleTutorial()
    {
        if (tutorialOn == false)
        {
            tutorialOn = true;
        }
        else if (tutorialOn == true)
        {
            tutorialOn = false;
        }
        
        Debug.Log(tutorialOn);
    }
}
