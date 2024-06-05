using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float rotateSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(rotateSpeed,0,0); 
    }
}
