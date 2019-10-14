using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubstractLives : MonoBehaviour
{
    public int Lives = 3;
    public Text LivesText;
    public GameObject GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stackables")
        {
            Lives = Lives - 1;
        }
    }

    void Update()
    {
        LivesText.text = "Lives: " + Lives;

        if (Lives == 0)
        {
            GameOver.SetActive(true);
        }
    }
}
