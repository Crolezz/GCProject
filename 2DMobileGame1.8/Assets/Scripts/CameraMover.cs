﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
     public float targetY;

    private void Start()
    {
        targetY = -0.2f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(transform.position.y, targetY, 1 * Time.deltaTime);
        transform.position = pos;
    }
}
