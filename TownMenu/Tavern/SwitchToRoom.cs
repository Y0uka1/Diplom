using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToRoom : ACSwitch
{
    public static int price;
    public override void Initialize()
    {
        base.Initialize();
        price = 1200 - (50 * TownManager.tavernManager.tavernLevel);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        TownManager.tavernManager.curType = RelaxType.Room;
    }

    public override void OnClick()
    {
        Debug.Log("OnClicked");

        List<ICharacterStats> onDelete = new List<ICharacterStats>(TownManager.tavernManager.room);
        for (int i = 0; i < TownManager.tavernManager.room.Count; i++)
        {
            Destroy(TownManager.tavernManager.charList.charListGO[TownManager.tavernManager.room[i]]);
            TownManager.tavernManager.bar.Remove(TownManager.tavernManager.room[i]);


        }
        foreach (var i in onDelete)
        {
            TownManager.charList.charList.Remove(i);
            TownManager.tavernManager.charList.charListGO.Remove(i);
        }
        base.OnClick();
    }
}
