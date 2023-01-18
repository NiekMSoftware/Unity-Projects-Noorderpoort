using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakePoint : MonoBehaviour
{
    private BasicCarController _basicCarController;

    [Header("AI controllers")]
    public BasicCarController ai1;


    public float speed_AI1;
    
    public bool isBraking;
    
    private void Awake()
    {
        _basicCarController = GetComponent<BasicCarController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (CompareTag("BrakePoint"))
        {
            ai1.speed = speed_AI1;
        }
        isBraking = true;
        
        //Add breaking force
        speed_AI1 = speed_AI1 * 0.5f;
    }
}
