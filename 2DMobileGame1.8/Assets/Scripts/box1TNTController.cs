﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box1TNTController : MonoBehaviour
{
    public Text exploText;

    private float nextExploCounter = 5f;

    public float a = 0;
    public float b = 0;

    void Start()
    {
        exploText = gameObject.GetComponentInChildren<Text>();
    }

    void Update()
    {
        GameObject S = this.gameObject;
        DetectStationary s = S.GetComponent<DetectStationary>();

        //shows the timer to explode in seconds (displayed on the box)
        if (nextExploCounter >= 0 &&  s.isStationary== false)
        {
            nextExploCounter -= Time.deltaTime;

            exploText.text = "" + Mathf.RoundToInt(nextExploCounter);
        }
        else if (nextExploCounter <= 0f && s.isStationary == false)
        {
            Destroy(gameObject);
        }
        if (s.isStationary == true)
        {
            Destroy(exploText);
        }

        //makes the text expand and retract after each second has passed 
        //adds feeling of urgency
        for (int i = 5; i >= 0; i--)
        {
            if (nextExploCounter <= i + 0.5f && nextExploCounter >= i + 0.35f)
            {
                a += Time.deltaTime / 0.15f;
                exploText.rectTransform.localScale = new Vector3(Mathf.Lerp(1f, 1.5f, a), Mathf.Lerp(1f, 1.5f, a), Mathf.Lerp(1f, 1.5f, a));   
            }
            if (nextExploCounter <= i + 0.35f && nextExploCounter >= i + 0.10f)
            {
                b += Time.deltaTime / 0.15f;
                exploText.rectTransform.localScale = new Vector3(Mathf.Lerp(1.5f, 1f, b), Mathf.Lerp(1.5f, 1, b), Mathf.Lerp(1.5f, 1f, b));
            }
        }
     
        //Debug.Log(nextExploCounter);
        //Debug.Log(DetectStationary.isStationary);
    }
}
