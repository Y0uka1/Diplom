using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class ACSwitch : MonoBehaviour, IPointerClickHandler
{
    /// Image icon;
   public Button confirm;

    public virtual void Initialize()
    {
        //  icon = GetComponent<Image>();
        confirm = transform.GetChild(2).GetComponent<Button>();
        confirm.onClick.AddListener(OnClick);
        CheckPrice();
    }


    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public virtual void OnClick() {
        ResourcesManager.money -= TownManager.tavernManager.totalPrice;
        TownManager.tavernManager.totalPrice = 0;
        TownManager.resourcesUI.Initialize();
        ResourcesData.SaveData();
        CheckPrice();
    }

    public virtual void CheckPrice()
    {
        if (TownManager.tavernManager.totalPrice > ResourcesManager.money)
        {
            confirm.interactable = false;
        }
        else
        {
            confirm.interactable = true;
        }

        if(TownManager.tavernManager.totalPrice == 0)
        {
            confirm.interactable = false;
        }
        confirm.GetComponentInChildren<Text>().text = TownManager.tavernManager.totalPrice.ToString();
    }
}
