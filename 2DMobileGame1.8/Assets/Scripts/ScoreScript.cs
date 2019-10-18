using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;
    public GameObject GoodText;
    public GameObject AmazingText;


     void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
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

    }
}