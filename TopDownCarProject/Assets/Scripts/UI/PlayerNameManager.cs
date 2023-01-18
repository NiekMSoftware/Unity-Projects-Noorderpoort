using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
     public InputField usernameInput;
     public string userInput;
    
    public void UserNameChanged()
    {
       userInput = usernameInput.text;
    }

}
