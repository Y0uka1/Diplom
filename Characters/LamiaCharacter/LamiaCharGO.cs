using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamiaCharGO : ICharObject
{
   private void OnMouseDown()
    {
        Debug.Log("select");
        OnClicked();
    }
   /* public void OnClicked()
    {
        if (MainManager.battleManager.currentTurn == TurnType.Player)
        {
            if (MainManager.battleManager.skill != null)
            {
                if (character.charType == CharacterType.Enemy)
                {
                    MainManager.battleManager.target = character;
                    MainManager.battleManager.OnTargetReady();
                }
            }
        }
    }*/

    public override void Initialize(ICharacterStats character)
    {
        SpriteRenderer sp = gameObject.AddComponent<SpriteRenderer>();
        sp.sprite = Resources.Load<Sprite>("Sprites/Characters/lamia");     
       
        this.character = character;
        this.character.link = this;
     
    }
}
