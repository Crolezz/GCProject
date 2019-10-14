using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntialVelocity : MonoBehaviour
{
    public Vector3 initVel;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = initVel;
    }


}
