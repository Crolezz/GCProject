using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStationary : MonoBehaviour
{
    private float timeToStationary = 1f;
    public static bool isStationary = false;
    private bool betweenStationary = false;

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Stackables")
        {
            betweenStationary = true;
            //timeToStationary -= Time.deltaTime;

            foreach (ContactPoint2D contact in other.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
            }
        }
    }

    void Update()
    {
        if (betweenStationary == true)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y >= -0.1f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.1f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0.1f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.x >= -0.1f)
            {
                timeToStationary -= Time.deltaTime;
            }
        }

        if (timeToStationary <= 0)
        {
            isStationary = true;
            ScoreScript.scoreAmount++;
            timeToStationary = 1000;
        }

        //Debug.Log(timeToStationary);
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

}
