using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToBar : ACSwitch
{
    public static int price;
    public override void Initialize()
    {
        base.Initialize();
         price = 200 -(50*TownManager.tavernManager.tavernLevel);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        TownManager.tavernManager.curType = RelaxType.Bar;
    }

    public override void OnClick()
    {

        List<ICharacterStats> onDelete = new List<ICharacterStats>(TownManager.tavernManager.bar);
        for (int i = 0; i < TownManager.tavernManager.bar.Count; i++)
        {
            Destroy(TownManager.tavernManager.charList.charListGO[TownManager.tavernManager.bar[i]]);
            TownManager.tavernManager.bar.Remove(TownManager.tavernManager.bar[i]);
            

        }
        foreach (var i in onDelete)
        {
            TownManager.charList.charList.Remove(i);
            TownManager.tavernManager.charList.charListGO.Remove(i);
        }
        base.OnClick();
    }

    
}
