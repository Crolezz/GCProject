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

    private Text scoreText;
    private Text LevelOverText;

    public GameObject GoodText;
    public GameObject AmazingText;
    public GameObject LevelOver;
    public GameObject NextLevelButton;

    


     void Start()
    {
        scoreText = GetComponent<Text>();
        LevelOverText = LevelOver.GetComponent<Text>();

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        scoreAmount = 0;
        CurrentLevel = 1;
    }

    void Update()
    {
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
            GameObject A = GameObject.Find("DeathTrigger");
            SubstractLives B = A.GetComponent<SubstractLives>();

            B.GameIsOver = true;
            LevelOver.SetActive(true);
            LevelOverText.text = "Congratulations! You have finished Level: " + CurrentLevel;
            CurrentLevel++;
            NextLevelButton.SetActive(true);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}