using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int scoreAmount;
    public static int CurrentLevel;
    private int nextSceneToLoad;
    private float deltaZoom;

    public float t = 0;

    private Text scoreText;
    private Text LevelOverText;
    private Text CurrentLevelText;

    public GameObject GoodText;
    public GameObject AmazingText;
    public GameObject LevelOver;
    public GameObject CurrentLevelTextObject;
    public GameObject NextLevelButton;
    public GameObject PlatformFalls;
    public Camera CameraModify;

    public GameObject GoodTextEffect;

    public BoxLauncher newNextFire;

     void Start()
    {
        CameraModify.GetComponent<Camera>();
        scoreText = GetComponent<Text>();
        LevelOverText = LevelOver.GetComponent<Text>();
        CurrentLevelText = CurrentLevelTextObject.GetComponent<Text>();

        newNextFire = GetComponent<BoxLauncher>();

        scoreAmount = 0;
        CurrentLevel = 1;
    }

    void Update()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        scoreText.text = "Score: " + scoreAmount;

        if (EndlessMode.thisMode == true)
        {
            CurrentLevelText.text = "Endless Mode";
            CurrentLevelText.fontSize = 15;
           
        }
        else if (EndlessMode.thisMode == false)
        {
            CurrentLevelText.text = "Level " + CurrentLevel;
        }
        
        //Modifies the announcements depending on what score the user is at
        if (scoreAmount >= 5 && scoreAmount <= 6)
        {
            GoodText.SetActive(true);           
        }
        else if (scoreAmount >= 10 && scoreAmount <= 11)
        {
            GoodText.SetActive(false);
            AmazingText.SetActive(true);
        }
        else
        {
            GoodText.SetActive(false);
            AmazingText.SetActive(false);
        }

        //Level Score Modifier
        if (EndlessMode.thisMode == false)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (CurrentLevel == i && scoreAmount >= 5 * i)
                {
                    SubstractLives.GameIsOver = true;
                    LevelOver.SetActive(true);
                    LevelOverText.text = "You have finished Level " + CurrentLevel;
                    NextLevelButton.SetActive(true);
                }
            } 
        }
        else if (EndlessMode.thisMode == true)
        {
            if (scoreAmount >= 100)
            {
                SubstractLives.GameIsOver = true;
                LevelOver.SetActive(true);
                LevelOverText.text = "You have finished Endless Mode";
            }
        }
        
        //This zooms out the camera liniarly when the game is over
        if (SubstractLives.GameIsOver == true)
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

        GameObject C = GameObject.Find("Main Camera");
        CameraMover D = C.GetComponent<CameraMover>();

        SceneManager.LoadScene(nextSceneToLoad);

        SubstractLives.GameIsOver = false;
        LevelOver.SetActive(false);
        NextLevelButton.SetActive(false);
        PlatformFalls.SetActive(true);
        GoodText.SetActive(false);
        AmazingText.SetActive(false);
        scoreAmount = 0;
        t = 0;
        CurrentLevel++;
        SubstractLives.Lives = 3;
        SubstractLives.waitFall = 6f;
        D.targetY = -0.2f;
        Time.timeScale = 1.0f;

        CameraModify.orthographicSize = 3.4f;
        CameraModify.transform.position = new Vector3(0, -1.11f, -10);

        newNextFire.nextFire = 3f;
    }
}