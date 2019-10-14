using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubstractLives : MonoBehaviour
{
    public int Lives = 3;
    public Text LivesText;
    public GameObject GameOver;
    public GameObject PlayAgain;
    public GameObject FinalScore;
    public GameObject Score;
    public Text FinalScoreText;
    public bool GameIsOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stackables" && Lives > 0)
        {
            Lives = Lives - 1;
        }
    }

    void Update()
    {
       
        LivesText.text = "Lives: " + Lives;
        FinalScoreText.text = "Final Score: " + ScoreScript.scoreAmount;

        if (Lives == 0)
        {
            GameOver.SetActive(true);
            PlayAgain.SetActive(true);
            FinalScore.SetActive(true);
            Score.SetActive(false);
            GameIsOver = true;
        }
    }
}
