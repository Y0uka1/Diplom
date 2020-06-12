using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToBordel : ACSwitch
{
    public static int price;
    public override void Initialize()
    {
        base.Initialize();
        price = 800 - (50 * TownManager.tavernManager.tavernLevel);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        TownManager.tavernManager.curType = RelaxType.Bordel;
    }

    public override void OnClick()
    {
        Debug.Log("OnClicked");

        List<ICharacterStats> onDelete = new List<ICharacterStats>(TownManager.tavernManager.bordel);
        for (int i = 0; i < TownManager.tavernManager.bordel.Count; i++)
        {
            Destroy(TownManager.tavernManager.charList.charListGO[TownManager.tavernManager.bordel[i]]);
            TownManager.tavernManager.bar.Remove(TownManager.tavernManager.bordel[i]);


        }
        foreach (var i in onDelete)
        {
            TownManager.charList.charList.Remove(i);
            TownManager.tavernManager.charList.charListGO.Remove(i);
        }
        base.OnClick();
    }
}

