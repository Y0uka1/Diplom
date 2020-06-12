using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToCasino : ACSwitch
{
    public static int price;
    public override void Initialize()
    {
        base.Initialize();
        price = 500 - (50 * TownManager.tavernManager.tavernLevel);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        TownManager.tavernManager.curType = RelaxType.Casino;
        Debug.Log("Clicked");
    }

   public  override void OnClick()
    {
        Debug.Log("OnClicked");


        List<ICharacterStats> onDelete = new List<ICharacterStats>(TownManager.tavernManager.casino);
        for (int i = 0; i < TownManager.tavernManager.casino.Count; i++)
        {
            Destroy(TownManager.tavernManager.charList.charListGO[TownManager.tavernManager.casino[i]]);
            TownManager.tavernManager.casino.Remove(TownManager.tavernManager.casino[i]);
           


        }
        foreach (var i in onDelete)
        {
            TownManager.charList.charList.Remove(i);
            TownManager.tavernManager.charList.charListGO.Remove(i);
        }
        base.OnClick();
    }
}
