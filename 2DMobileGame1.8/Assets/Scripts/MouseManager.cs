using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public LineRenderer dragLine;    //Symbole [] {}    

    float dragSpeed = 10f;
    Rigidbody2D grabbedObject = null;

    Vector3 touchPosWorld;

    TouchPhase touchPhaseB = TouchPhase.Began;
    TouchPhase touchPhaseE = TouchPhase.Ended;

    Vector3 initalTouch;
    Vector3 direction;

    void Update()
    {    //this makes it so that you can't
         //grab any object when the game is over

        if (Input.GetMouseButtonDown(0) && SubstractLives.GameIsOver == false)
        {
            //Clicked
            Vector3 MouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(MouseWorldPos3D.x, MouseWorldPos3D.y);
            Vector2 Direction = Vector2.zero;
            RaycastHit2D HitTest = Physics2D.Raycast(MousePos2D, Direction);
            if (HitTest && HitTest.collider != null)
            {
                if (HitTest.collider.GetComponent<Rigidbody2D>() != null)
                {
                    grabbedObject = HitTest.collider.GetComponent<Rigidbody2D>();
                    grabbedObject.gravityScale = 0;
                    //dragLine.enabled = true;
                }
            }
        }
        
        if (Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            grabbedObject.gravityScale = 1;
            grabbedObject = null;
            dragLine.enabled = false;
        }


        //Touch controls
        /* 
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhaseB)
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if (hitInformation.collider != null)
            {
                grabbedObject = hitInformation.collider.GetComponent<Rigidbody2D>();
                grabbedObject.gravityScale = 0;
                dragLine.enabled = true;
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhaseE && grabbedObject != null)
        {
            grabbedObject.gravityScale = 1;
            grabbedObject = null;
            dragLine.enabled = false;
        }

        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            Vector3 initalTouch = Input.GetTouch(1).position;
        }

        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            Debug.Log("Second finger");
            Vector3 currentTouch = Input.GetTouch(1).deltaPosition;
            Vector3 direction = (initalTouch - currentTouch).normalized;
            
            if (direction.x > initalTouch.x)
            {
                float objRotation = grabbedObject.rotation;
                grabbedObject.SetRotation(objRotation + 5.0f);
            }

            if (direction.x < initalTouch.x)
            {
                float objRotation = grabbedObject.rotation;
                grabbedObject.SetRotation(objRotation - 5.0f);
            }

        }
         
        */

    }
    void FixedUpdate()
    {
        if (grabbedObject != null)
        {
            // Move the object with the mouse
            Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);

            Vector2 dir = mousePos2D - grabbedObject.position;

            dir *= dragSpeed;

            grabbedObject.velocity = dir;
        }

        // Touch controls
        /* 
        if (grabbedObject != null)
        {
            // Move the object with touch
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            Vector2 dir = touchPosWorld2D - grabbedObject.position;

            dir *= dragSpeed;

            grabbedObject.velocity = dir;
        }
        
        */


    }
    void LateUpdate()
    {
        if (grabbedObject != null)
        {
            Vector3 MouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(MouseWorldPos3D.x, MouseWorldPos3D.y);
            dragLine.SetPosition(0, new Vector3(grabbedObject.position.x, grabbedObject.position.y, -1));
            dragLine.SetPosition(1, new Vector3(MousePos2D.x, MousePos2D.y, -1));
        }
        //Touch controls
        /*        
        if (grabbedObject != null)
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            dragLine.SetPosition(0, new Vector3(grabbedObject.position.x, grabbedObject.position.y, -1));
            dragLine.SetPosition(1, new Vector3(touchPosWorld2D.x, touchPosWorld2D.y, -1));
        }
        */


    }
}