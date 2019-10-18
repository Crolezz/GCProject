using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStationary : MonoBehaviour
{
    private float timeToStationary = 1f;
    public bool isStationary = false;

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Stackables")
        {      
            timeToStationary -= Time.deltaTime;

            foreach (ContactPoint2D contact in other.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
            }
        }
    }

    void Update()
    { 

        if (timeToStationary <= 0)
        {
            isStationary = true;
            ScoreScript.scoreAmount++;
            timeToStationary = 1000;
        }

        //Debug.Log(timeToStationary);
    }

}
