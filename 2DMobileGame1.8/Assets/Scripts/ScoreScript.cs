using System.Collections;
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

        if (scoreAmount >= 5 && scoreAmount < 10)
        {
            GoodText.SetActive(true);
        }
        else if (scoreAmount >= 10)
        {
            GoodText.SetActive(false);
            AmazingText.SetActive(true);
        }

        if (CurrentLevel == 1 && scoreAmount >= 2)
        {
            B.GameIsOver = true;
            LevelOver.SetActive(true);
            LevelOverText.text = "Congratulations! You have finished Level: " + CurrentLevel;
            CurrentLevel++;
            NextLevelButton.SetActive(true);
        }

        //This zooms out the camera liniarly when the game is over
        if (B.GameIsOver == true)
        {
            t += Time.deltaTime / 3f;  //3 represents the duration (in seconds) in which you want to zoom out
            CameraModify.orthographicSize = Mathf.Lerp(3, 5, t);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}