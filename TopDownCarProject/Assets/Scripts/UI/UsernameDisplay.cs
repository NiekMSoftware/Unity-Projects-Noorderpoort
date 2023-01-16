using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UsernameDisplay : MonoBehaviour
{
    public string textUser;
    private GameObject userOfText;

    public Text userText;
    private NameTransfer _nameTransfer;

    private void Awake()
    {
        _nameTransfer = GetComponent<NameTransfer>();
    }

    private void Update()
    {
        
    }
}
