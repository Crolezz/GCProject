using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLauncher : MonoBehaviour
{
    public GameObject[] boxPrefabs;
    public float fireDelay = 3f;
    public static float nextFire = 1f;

    public float fireVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (ScoreScript.CurrentLevel == 2)
        {
            fireDelay = 6f; //Divide it by 2 for seconds
        }
    }
    void FixedUpdate()
    {
        nextFire -= Time.deltaTime;

        //if the game is over, no more objects will be fired
        if (nextFire <= 0 && SubstractLives.GameIsOver == false)
         {
            nextFire = fireDelay;

            GameObject boxGO = (GameObject)Instantiate(boxPrefabs[Random.Range(0, boxPrefabs.Length)],
                 transform.position,
                 transform.rotation
                        );

            boxGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, fireVelocity);
         }

           
    }
}
