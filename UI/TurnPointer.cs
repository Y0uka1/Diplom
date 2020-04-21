using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPointer : MonoBehaviour , IManager
{
    Vector2 curCharPosition;
    
    SpriteRenderer pointerSprite;
    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;
   

    
    public void Initialize()
    {
        pointerSprite = GetComponent<SpriteRenderer>();
        
        MainManager.battleManager.OnTurnChangesEvent += ChangePos;
        ChangePos();
        status = ManagerStatus.Initialized;
    }

    void ChangePos()
    {
        curCharPosition = MainManager.battleManager.currentChar.link.transform.position;
        transform.position = new Vector2(curCharPosition.x, curCharPosition.y - 4);
        Debug.Log("OOOOOOOOOOOOOOOOOOOM");
    }
}
