﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LamiaPicker : ACPicker
{
    //Button button;
    //ICharacterStats character;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        character = new LamiaChar();
        GetComponentInChildren<Text>().text = "Lamia";
    }
    
}
