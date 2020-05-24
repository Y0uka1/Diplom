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

    public void Initialize()
    {
        placeholderImage =this.gameObject.transform.GetChild(0).GetComponent<Image>();
        placeholderImage.enabled = false;
        TownManager.teamBuilder.Activate += OnPlaceholderActivate;
       TownManager.teamBuilder.placeholders[index] = this;
    }

    private void OnPlaceholderActivate()
    {
        if (TownManager.teamBuilder.activePlaceholder != this)
        {
            placeholderImage.enabled = false;
        }
        else
        {
            placeholderImage.enabled = true;
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
        TownManager.teamBuilder.activePlaceholder = this;
        TownManager.teamBuilder.PlaceholderActivate();
       

    }

    
}
