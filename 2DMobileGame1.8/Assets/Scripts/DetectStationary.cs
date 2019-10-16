using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStationary : MonoBehaviour
{
    private float timeToStationary = 2f;
    private bool A = false;
    public bool isStationary = false;

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Stackables")
        {
            A = true;
        }
        
    }

    void Update()
    {
        if (A == true)
        {
            timeToStationary -= Time.deltaTime;
        }

        if (timeToStationary <= 0)
        {
            isStationary = true;
            ScoreScript.scoreAmount++;
            timeToStationary = 1000;
        }

        //Debug.Log(timeToStationary);
    }

}
