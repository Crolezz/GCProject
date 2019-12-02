using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SubstractLives.GameIsOver == false)
        {
            //Clicked
            Vector3 MouseWorldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(MouseWorldPos3D.x, MouseWorldPos3D.y);
            Vector2 Direction = Vector2.zero;
            RaycastHit2D HitTest = Physics2D.Raycast(MousePos2D, Direction);

            if (HitTest.collider.GetComponent<Rigidbody2D>() != null && HitTest.collider.CompareTag("LifeUp"))
            {
                SubstractLives.Lives = SubstractLives.Lives + 1;
                Destroy(gameObject);
            }



        }
    }
}
