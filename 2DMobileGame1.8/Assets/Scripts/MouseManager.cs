using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public LineRenderer dragLine;    //Symbole [] {}    

    float dragSpeed = 10f;
    Rigidbody2D grabbedObject = null;

    void Update()
    {
        GameObject C = GameObject.Find("DeathTrigger");               //this makes it so that you can't
        SubstractLives D = C.GetComponent<SubstractLives>();          //grab any object when the game is over

        if (Input.GetMouseButtonDown(0) && D.GameIsOver == false)
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
    }
}