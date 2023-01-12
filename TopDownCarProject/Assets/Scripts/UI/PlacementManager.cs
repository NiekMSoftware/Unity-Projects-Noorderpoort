using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "CarBody")
        {
            Console.WriteLine("Passed");
        }

        if (other.transform.name == "AiBody")
        {
            Console.WriteLine("ai passed");
        }
    }

    
    
}
