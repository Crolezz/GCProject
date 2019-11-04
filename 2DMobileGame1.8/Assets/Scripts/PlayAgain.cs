using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
  
    public void StartAgain()
    {
        GameObject A = GameObject.Find("DDOL");
        DontDesOnLoad B = A.GetComponent<DontDesOnLoad>();

        for (int i = 0; i < B.GetRidOfIt.Length; i++)
        {
            Destroy(B.GetRidOfIt[i]);
        }

        SceneManager.LoadScene("LEVEL1");
        SubstractLives.Lives = 3;
        SubstractLives.GameIsOver = false;
    }
}
