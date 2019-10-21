﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int scoreAmount;
    private int CurrentLevel;
    private int nextSceneToLoad;
    private float deltaZoom;
    public float t = 0;

    private Text scoreText;
    private Text LevelOverText;

    public GameObject GoodText;
    public GameObject AmazingText;
    public GameObject LevelOver;
    public GameObject NextLevelButton;
    public GameObject PlatformFalls;
    public Camera CameraModify;

     void Start()
    {
        CameraModify.GetComponent<Camera>();
        scoreText = GetComponent<Text>();
        LevelOverText = LevelOver.GetComponent<Text>();

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        scoreAmount = 0;
        CurrentLevel = 1;
    }

    void Update()
    {
        GameObject A = GameObject.Find("DeathTrigger");
        SubstractLives B = A.GetComponent<SubstractLives>();

        scoreText.text = "Score: " + scoreAmount;

        //Modifies the announcements depending on what score the user is at
        if (scoreAmount >= 5 && scoreAmount < 6)
        {
            GoodText.SetActive(true);
        }
        else if (scoreAmount >= 10 && scoreAmount < 11)
        {
            GoodText.SetActive(false);
            AmazingText.SetActive(true);
        }

        //Level Score Modifier
        if (CurrentLevel == 1 && scoreAmount >= 2)
        {
            B.GameIsOver = true;
            LevelOver.SetActive(true);
            LevelOverText.text = "Congratulations! You have finished Level: " + CurrentLevel;
            NextLevelButton.SetActive(true);
        }

        if (CurrentLevel == 2 && scoreAmount >= 2)
        {
            Debug.Log("Level 2 Finished");
        }

        //This zooms out the camera liniarly when the game is over
        if (B.GameIsOver == true)
        {
            t += Time.deltaTime / 3f;  //3 represents the duration (in seconds) in which you want to zoom out
            CameraModify.orthographicSize = Mathf.Lerp(3, 5, t);
        }
    }

    //This scripts resets the values for the next level and decides
    //what to do before the level has started
    public void NextLevel()
    {
        GameObject A = GameObject.Find("DeathTrigger");
        SubstractLives B = A.GetComponent<SubstractLives>();

        SceneManager.LoadScene(nextSceneToLoad);

        B.GameIsOver = false;
        LevelOver.SetActive(false);
        NextLevelButton.SetActive(false);
        PlatformFalls.SetActive(true);
        scoreAmount = 0;
        CurrentLevel++;
        SubstractLives.Lives = 3;
        BoxLauncher.nextFire = 3f;

        CameraModify.orthographicSize = 3;
    }
}