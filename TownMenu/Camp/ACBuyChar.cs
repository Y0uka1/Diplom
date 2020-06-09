using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ACBuyChar : MonoBehaviour
{
    Button button;
    public virtual void Initialize()
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(BuyNewChar);
        if (ResourcesManager.humans < 1)
            button.interactable = false;
        else
            button.interactable = true;
    }

    public virtual void BuyNewChar()
    {
        ResourcesManager.humans--;
        ResourcesData.OnChange();
    }
}
