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

            if (HitTest.collider.GetComponent<Rigidbody2D>() != null && HitTest.collider.CompareTag("SlowTime"))
            {
                Time.timeScale = 0.5f;
                StartCoroutine(AfterTime(2.0f));
                gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

        }
    }

    IEnumerator AfterTime (float time)
    {
        Debug.Log("test");

        yield return new WaitForSeconds(time);
        Debug.Log("test");
        Time.timeScale = 1.0f;
        Destroy(gameObject);
        gameObject.GetComponent<DeathTrigger>().enabled = false;
    }
}
