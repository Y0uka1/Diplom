using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DridaCharGObject : ICharObject
{
    private void OnMouseDown()
    {
        Debug.Log("select");
        OnClicked();
    }

    
    public override void Initialize(ICharacterStats character)
    {
        SpriteRenderer sp = gameObject.AddComponent<SpriteRenderer>();
        sp.sprite = Resources.Load<Sprite>("Prefabs/TempChar/e3");

        this.character = character;
        this.character.link = this;

        
    }
}
