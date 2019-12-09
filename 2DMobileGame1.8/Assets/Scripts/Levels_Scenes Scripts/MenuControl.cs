using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public string mainMenuScene;
    public string restartLvl;
    public GameObject pauseMenu;
    public bool isPaused;
    public AudioSource BackTrack;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Togglesc);
        BackTrack.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;

            }
        }
       
    }

    public void Togglesc()
    {
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume");
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameObject A = GameObject.Find("DDOL");
        DontDesOnLoad B = A.GetComponent<DontDesOnLoad>();

        for (int i = 0; i < B.GetRidOfIt.Length; i++)
        {
            Destroy(B.GetRidOfIt[i]);
        }

        SceneManager.LoadScene("LEVEL1");
        SubstractLives.Lives = 3;
        SubstractLives.GameIsOver = false;
        BoxLauncher.showTutorialOnce = true;
        BoxLauncher.nextStartGameTimer = 4f;
        SceneManager.LoadScene("LEVEL1");
        isPaused = false;
        pauseMenu.SetActive(false);

    }

    public void RTNmainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("START SCREEN");

        GameObject A = GameObject.Find("DDOL");
        DontDesOnLoad B = A.GetComponent<DontDesOnLoad>();

        for (int i = 0; i < B.GetRidOfIt.Length; i++)
        {
            Destroy(B.GetRidOfIt[i]);
        }

        EndlessMode.thisMode = false;
        DDToggleTutorial.tutorialOn = false;
    }
  
}
