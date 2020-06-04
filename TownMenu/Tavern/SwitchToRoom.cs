using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchToRoom : MonoBehaviour, IPointerClickHandler
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
        Debug.Log("Clicked");
        TownManager.tavernManager.curType = RelaxType.Room;
    }

    void OnClick()
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

    }
}
