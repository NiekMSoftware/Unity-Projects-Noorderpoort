using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;
    void Update()
    {
        //Make the player respawn after a certain Y value
        if (player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }
    }
    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }
}
