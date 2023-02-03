using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class WaterDeath : MonoBehaviour
{
    /*
     * Get the Checkpoint script
     */ 
    private CheckpointManager _cpManager;

    //Add a gameObject
    public GameObject waterPlane;
    
    //Check if player hit the water
    public bool hitWater;

    private void Awake()
    {
        _cpManager = GetComponent<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
         * Check if the player hit the water
         */
        if (other.CompareTag("Player"))
        {
            print("Hit water!");
            hitWater = true;
        }
    }
}
