using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToCasino : MonoBehaviour, IPointerClickHandler
{
    /// Image icon;
    Button confirm;
    Image levelUp;

    public void Initialize()
    {
        //  icon = GetComponent<Image>();
        confirm = transform.GetChild(2).GetComponent<Button>();
        confirm.onClick.AddListener(OnClick);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        TownManager.tavernManager.curType = RelaxType.Casino;
        Debug.Log("Clicked");
    }

    void OnClick()
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
    }
}
