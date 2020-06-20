using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LamiaPicker : ACPicker
{
   
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        //   character = new LamiaChar();
        avatar = GetComponent<Image>();
        avatar.sprite = Resources.Load<Sprite>("Sprites/Characters/Avatars/nunAvatar");
       // GetComponentInChildren<Text>().text = "Целительница";
    }
    
}
