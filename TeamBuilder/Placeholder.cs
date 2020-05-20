using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Placeholder : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public ICharacterStats character;
    
    public Image placeholderImage;

    private void Start()
    {
        placeholderImage =this.gameObject.transform.GetChild(0).GetComponent<Image>();
        placeholderImage.color = new Color(255, 255, 255, 0);
        MainManager.teamBuilder.Activate += OnPlaceholderActivate;
        MainManager.teamBuilder.placeholders[index] = this;
    }

    private void OnPlaceholderActivate()
    {
        if (MainManager.teamBuilder.activePlaceholder != this)
        {
            placeholderImage.color = new Color(255, 255, 255, 0);
        }
        else
        {
            placeholderImage.color = new Color(255, 255, 255, 255);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        /*if(TeamBuilder.tempCharacter!=null)
        {
            character = TeamBuilder.tempCharacter;
            TeamBuilder.tempCharacter = null;
        }*/
        //TeamBuilder.characterList.content.
        MainManager.teamBuilder.activePlaceholder = this;
        MainManager.teamBuilder.PlaceholderActivate();
       

    }

    
}
