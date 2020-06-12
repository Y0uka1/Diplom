using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPointer : MonoBehaviour , IManager
{
    Vector2 curCharPosition;
    
    SpriteRenderer pointerSprite;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
   

    
    public void Initialize()
    {
        pointerSprite = GetComponent<SpriteRenderer>();
        pointerSprite.enabled = true;
        MainManager.battleManager.OnTurnChangesEvent += ChangePos;
        ChangePos();
        status = ManagerStatus.Online;
    }

    void ChangePos()
    {
        if (MainManager.battleManager.currentChar != null)
        {
            if (MainManager.battleManager.currentChar.link != null)
            {
                curCharPosition = MainManager.battleManager.currentChar.link.transform.position;
                transform.position = new Vector2(curCharPosition.x, curCharPosition.y - 4);
            }
        }
        else
            pointerSprite.enabled = false;
    }
}
