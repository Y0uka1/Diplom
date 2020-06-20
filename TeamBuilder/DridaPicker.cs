using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DridaPicker :  ACPicker
{

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        //   character = new LamiaChar();
        avatar = GetComponent<Image>();
        avatar.sprite = Resources.Load<Sprite>("Sprites/Characters/Avatars/DridaAvatar");
      
      //  GetComponentInChildren<Text>().text = "Леший";
    }

}
