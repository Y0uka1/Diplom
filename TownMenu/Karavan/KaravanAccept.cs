using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaravanAccept : MonoBehaviour
{
    Button button;
    Text text;
    int total;
    bool accepted ;

    private void Start()
    {
        accepted = false;
    }

    public void Initialize()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Accept);
        CountTotal();
    }

    void Accept()
    {
        MainManager.requestedResources.armorShard = TownManager.karavanManager.trade.arm1CountInt;
        MainManager.requestedResources.armorChunck = TownManager.karavanManager.trade.arm2CountInt;
        MainManager.requestedResources.armorSlab = TownManager.karavanManager.trade.arm3CountInt;

        MainManager.requestedResources.weaponShard = TownManager.karavanManager.trade.wep1CountInt;
        MainManager.requestedResources.weaponChunk = TownManager.karavanManager.trade.wep2CountInt;
        MainManager.requestedResources.weaponSlab = TownManager.karavanManager.trade.wep3CountInt;

        MainManager.requestedResources.money = TownManager.karavanManager.request.moneyVal;
        MainManager.requestedResources.buildMaterials = TownManager.karavanManager.request.buildVal;
        MainManager.requestedResources.humans = TownManager.karavanManager.request.humanVal/40;


        ResourcesManager.money -= total;

        MainManager.requestedResources.SaveData();
        ResourcesData.OnChange();
        button.interactable = false;
        accepted = true;
    }
    void CountTotal()
    {
        total = 0;
        total += TownManager.karavanManager.trade.arm1PriceInt * TownManager.karavanManager.trade.arm1CountInt;
        total += TownManager.karavanManager.trade.arm2PriceInt * TownManager.karavanManager.trade.arm2CountInt;
        total += TownManager.karavanManager.trade.arm3PriceInt * TownManager.karavanManager.trade.arm3CountInt;

        total += TownManager.karavanManager.trade.wep1PriceInt * TownManager.karavanManager.trade.wep1CountInt;
        total += TownManager.karavanManager.trade.wep2PriceInt * TownManager.karavanManager.trade.wep2CountInt;
        total += TownManager.karavanManager.trade.wep3PriceInt * TownManager.karavanManager.trade.wep3CountInt;

        text.text = $"Всего:{total.ToString()}\nПодтвердить";
    }

    public void PriceCheck()
    {
        CountTotal();
        if (ResourcesManager.money > total && !accepted)
            button.interactable = true;
        else
            button.interactable = false;
    }
}
