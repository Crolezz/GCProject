using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDesOnLoad : MonoBehaviour
{ 
    public GameObject[] GetRidOfIt;

    void Update()
    {
        if (SubstractLives.GameIsOver == false)
        {
            for (int i = 0; i < GetRidOfIt.Length; i++)
            {
                DontDestroyOnLoad(GetRidOfIt[i]);
            }
        }
        
    }
}
