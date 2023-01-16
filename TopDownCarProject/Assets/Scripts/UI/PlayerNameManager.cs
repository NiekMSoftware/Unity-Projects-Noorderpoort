using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    static public InputField usernameInput;
    static public string userInput;
    
    public void UserNameChanged()
    {
       userInput = usernameInput.text;
    }

}
