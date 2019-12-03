using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLauncher : MonoBehaviour
{
    public GameObject[] boxPrefabs;
    public GameObject grayImage;

    public float fireDelay = 6f;
    public static float nextFire = 3f;

    private float startGameTimer = 0f;
    public static float nextStartGameTimer = 27f;  //set the seconds that you want to wait before the game starts (only works when the game first starts)
    private bool canStartGame = false;             //the amount of seconds is nextStartGameTimer / 2              (not when you click "Play Again")
    public static bool showTutorialOnce = false;   

    public float fireVelocity = 10f;

    public AudioSource ObjectThrow;

    void Start()
    {                           
        if (showTutorialOnce == false && DDToggleTutorial.tutorialOn == true)
        {
            grayImage.SetActive(true);
        }
    }

    void Update()
    {
        if (ScoreScript.CurrentLevel == 3 && ScoreScript.scoreAmount >= 10)
        {
            fireDelay = 4.5f; //Divide it by 2 for seconds
        }

        nextStartGameTimer -= Time.deltaTime;

        if (nextStartGameTimer <= startGameTimer && DDToggleTutorial.tutorialOn == true)
        {
            canStartGame = true;
            showTutorialOnce = true;
            grayImage.SetActive(false);
        }
        else if (DDToggleTutorial.tutorialOn == false)
        {
            canStartGame = true;
        }
    }
    void FixedUpdate()
    {
        nextFire -= Time.deltaTime;

        //if the game is over, no more objects will be fired
        //if canStartGame is true then the game starts launching boxes
        if (nextFire <= 0 && SubstractLives.GameIsOver == false && canStartGame == true)
         {
            nextFire = fireDelay;

            GameObject boxGO = Instantiate(boxPrefabs[Random.Range(0, boxPrefabs.Length)],
                 transform.position,
                 Quaternion.identity
                        );

            boxGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, fireVelocity);
            ObjectThrow.Play();
            
         }
        Debug.Log(nextFire);
    }
}
