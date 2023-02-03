using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LapScript : MonoBehaviour
{
    public TMP_Text LapNumber;
    public int Lap = 1;

    public GameObject speedometer;
    public GameObject lapCounter;
    public GameObject finished;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("AI"))
        {
            AddLap();
        }
    }
    private void AddLap()
    {
        Lap++;
        LapNumber.text = Lap.ToString();
        if(Lap > 3)
        {
            Finished();
        }
    }

    void Finished()
    {
        speedometer.SetActive(false);
        lapCounter.SetActive(false);
        Time.timeScale = 0f;
        finished.SetActive(true);
    }
}