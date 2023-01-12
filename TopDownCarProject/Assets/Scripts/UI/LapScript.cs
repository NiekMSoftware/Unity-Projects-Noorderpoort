using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapScript : MonoBehaviour
{
    public Text LapNumber;
    public int Lap = 1;

    private void OnTriggerEnter(Collider other)
    {
        print("object detected");
        if (other.gameObject.CompareTag("Player"))
        {
            print("player detected");
            AddLap();
        }
    }
    private void AddLap()
    {
        Lap++;
        LapNumber.text = Lap.ToString();
        if(Lap > 3)
        {
            // SceneManager.LoadScene("MainMenu");
        }
    }
}