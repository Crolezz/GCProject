using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubstractLives : MonoBehaviour
{
    public int Lives = 3;
    private float waitFall = 6f;
    public Text LivesText;
    public GameObject GameOver;
    public GameObject PlayAgain;
    public GameObject FinalScore;
    public GameObject Score;
    public GameObject PlatformFalls;
    public Text FinalScoreText;
    public bool GameIsOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stackables" && Lives > 0 && GameIsOver == false)
        {
            Lives = Lives - 1;
        }
    }

    void Update()
    {
       
        LivesText.text = "Lives: " + Lives;
        FinalScoreText.text = "Final Score: " + ScoreScript.scoreAmount;

        //used for displaying the Play Again button and all other game over texts
        if (Lives == 0)
        {
            GameOver.SetActive(true);
            PlayAgain.SetActive(true);
            FinalScore.SetActive(true);
            Score.SetActive(false);
            GameIsOver = true;
        }

        if (GameIsOver == true)
        {
            waitFall -= Time.deltaTime;

            if (waitFall <= 0f)
            {
                PlatformFalls.SetActive(false);
            }
        }
    }
}
