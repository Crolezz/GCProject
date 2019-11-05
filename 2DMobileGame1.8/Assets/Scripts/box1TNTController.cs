using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box1TNTController : MonoBehaviour
{
    public Text exploText;

    private float nextExplo = 0f;
    private float nextExploCounter = 5;

    void Start()
    {
        exploText = gameObject.GetComponentInChildren<Text>();
    }

    
    void Update()
    {
        if (nextExploCounter > 0)
        {
            nextExploCounter -= Time.deltaTime;

            exploText.text = "" + Mathf.RoundToInt(nextExploCounter);
        }
        else
        {
            Destroy(gameObject);
        }

        if (nextExploCounter <= 3.5f)
        {
            exploText.fontSize = 120;
        }
    }
}
