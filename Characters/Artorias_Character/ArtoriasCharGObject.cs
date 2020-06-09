using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtoriasCharGObject : ICharObject
{
     string prefabWay  = "Prefabs/ArtoriasPrefab";


   private void OnMouseDown()
    {
        Debug.Log("select");
        OnClicked();
    }
   
   /* public void OnTurnChanges()
    {
        if (MainManager.battleManager.currentChar == character)
        {
            Debug.Log(name);
        }
    }*/
    public override void Initialize(ICharacterStats character)
    {
        SpriteRenderer sp = gameObject.AddComponent<SpriteRenderer>();
        sp.sprite = Resources.Load<Sprite>("Sprites/Characters/ArtoriasStandBattle");
       
        this.character = character;
        this.character.link = this;
       
        /* HealthBarManager hBar = gameObject.AddComponent<HealthBarManager>();
         hBar.Initialize(character);
         hBar.RefreshPos();*/
        //MainManager.battleManager.OnTurnChangesEvent += OnTurnChanges;
    }
}
