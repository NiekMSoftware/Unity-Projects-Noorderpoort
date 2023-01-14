using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    public GameObject selectLevel;
    public GameObject mainMenu;
   
    public void PlayGame()
    {
        selectLevel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void turnOffObject()
    {
        mainMenu.SetActive(false);
    }
}
