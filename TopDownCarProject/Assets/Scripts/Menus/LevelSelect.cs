using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   public GameObject mainMenu;
   public GameObject levelSelector;

   public void playCircuit1()
   {
      SceneManager.LoadScene("Circuit1");
   }

   public void playCircuit2()
   {
      SceneManager.LoadScene("Circuit2");
   }
   
   public void returnToMenu()
   {
      mainMenu.SetActive(true);
   }

   public void deactivateLevelSelector()
   {
      levelSelector.SetActive(false);
   }
}
