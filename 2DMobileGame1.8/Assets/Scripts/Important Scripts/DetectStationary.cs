using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStationary : MonoBehaviour
{
    private float timeToStationary = 0.75f;
    public bool isStationary = false;
    public bool betweenStationary = false;
    private bool playThis = false;
    private bool checkStationary = false;


    public AudioSource ObjectDrop;

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Stackables")
        {
            betweenStationary = true;
            //Play sound when objects collide with each other or platform
            if (playThis == false)
            {
                playThis = true;
                ObjectDrop.Play();
            }
            
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
            if (gameObject.GetComponent<Rigidbody2D>().velocity.y >= -0.2f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.2f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0.2f &&
                gameObject.GetComponent<Rigidbody2D>().velocity.x >= -0.2f)
            {
                timeToStationary -= Time.deltaTime;
            }
        }

        if (timeToStationary <= 0 && SubstractLives.GameIsOver == false)
        {
            if (!checkStationary)
            {
                isStationary = true;
                ScoreScript.scoreAmount++;
                checkStationary = true;
            }
            
            
        }
        //Debug.Log(timeToStationary);
        
        if (SubstractLives.GameIsOver == true)
        {
            timeToStationary = 1f;
        }
    }

}
