﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempBut : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
       
    }


    void OnClick()
    {
       MainManager.charSave.SaveData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
