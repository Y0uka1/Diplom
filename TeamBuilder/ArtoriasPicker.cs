using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtoriasPicker : ACPicker
{
   
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        avatar = GetComponent<Image>();
        avatar.sprite = Resources.Load<Sprite>("Sprites/Characters/Avatars/plutAvatar");
      //  character = new Artorias_Character();
        GetComponentInChildren<Text>().text = "Artorias";
    }

    
}
