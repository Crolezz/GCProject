using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class box1TNTController : MonoBehaviour
{
    public Text exploText;

    private float nextExplo = 0f;
    private float nextExploCounter = 5;

    public float a = 0;
    public float b = 0;

    void Start()
    {
        exploText = gameObject.GetComponentInChildren<Text>();
    }

    
    void Update()
    {
        //shows the timer to explode in seconds (displayed on the box)
        if (nextExploCounter >= 0 && DetectStationary.isStationary == false)
        {
            nextExploCounter -= Time.deltaTime;

            exploText.text = "" + Mathf.RoundToInt(nextExploCounter);
        }
        else if (nextExploCounter <= 0)
        {
            Destroy(gameObject);
        }
        if (DetectStationary.isStationary == true)
        {
            Destroy(exploText);
        }

        //makes the text expand and retract after each second has passed 
        //adds feeling of urgency
        for (int i = 5; i >= 0; i--)
        {
            if (nextExploCounter <= i + 0.5f && nextExploCounter >= i + 0.35f)
            {
                a += Time.deltaTime / 0.15f;
                exploText.rectTransform.localScale = new Vector3(Mathf.Lerp(0.004f, 0.006f, a), Mathf.Lerp(0.004f, 0.006f, a), Mathf.Lerp(0.004f, 0.006f, a));   
            }
            if (nextExploCounter <= i + 0.35f && nextExploCounter >= i + 0.10f)
            {
                b += Time.deltaTime / 0.15f;
                exploText.rectTransform.localScale = new Vector3(Mathf.Lerp(0.006f, 0.004f, b), Mathf.Lerp(0.006f, 0.004f, b), Mathf.Lerp(0.006f, 0.004f, b));
            }
        }
     
        Debug.Log(a);
    }
}
