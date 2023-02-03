using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

public class CheckpointManager : MonoBehaviour
{ 
    public UnityEvent checkpointReached;

    public bool hitCheckPoint;
    
    public GameObject currentCheckPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "CarBody")
        {
            hitCheckPoint = true;
            checkpointReached.Invoke();
            if (other.CompareTag("Player"))
            {
                SafePlayerCheckPoint();
            }
        }
    }
    public void SafePlayerCheckPoint()
    {
        currentCheckPoint = GetComponent<GameObject>();
        print("Hit the CP!");
    }
}
