using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsScript : MonoBehaviour
{
    public GameObject GoodTextEffect;
    public GameObject followCamera;

    private bool goodIsOn = false;
    private bool awesomeIsOn = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (ScoreScript.scoreAmount == 5 && goodIsOn == false)
        {
            Instantiate(GoodTextEffect, new Vector3(followCamera.transform.position.x, followCamera.transform.position.y + 2.17f, 0), Quaternion.identity);

            goodIsOn = true;
        }
        if (ScoreScript.scoreAmount == 10 && awesomeIsOn == false)
        {
            Instantiate(GoodTextEffect, new Vector3(followCamera.transform.position.x, followCamera.transform.position.y + 2.17f, 0), Quaternion.identity);

            awesomeIsOn = true;
        }
    }
}
