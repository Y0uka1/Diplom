using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Text money;
    Text build;
    Text torch;
    Text food;
    Text human;
    Text wep1;
    Text wep2;
    Text wep3;
    Text arm1;
    Text arm2;
    Text arm3;

    public void Initialize()
    {
        torch = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        food = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        money = transform.GetChild(2).GetChild(0).GetComponent<Text>();
        build = transform.GetChild(3).GetChild(0).GetComponent<Text>();
        human = transform.GetChild(4).GetChild(0).GetComponent<Text>();
        wep1 = transform.GetChild(5).GetChild(0).GetComponent<Text>();
        wep2 = transform.GetChild(6).GetChild(0).GetComponent<Text>();
        wep3 = transform.GetChild(7).GetChild(0).GetComponent<Text>();
        arm1 = transform.GetChild(8).GetChild(0).GetComponent<Text>();
        arm2 = transform.GetChild(9).GetChild(0).GetComponent<Text>();
        arm3 = transform.GetChild(10).GetChild(0).GetComponent<Text>();


        MainManager.inventory.OnLootGet += Refresh;
    }

    void Refresh()
    {
        try {  torch.text = MainManager.inventory.availableResources[ResourceTypes.Torch].ToString(); } catch { torch.text = torch.text; }
        try { food.text = MainManager.inventory.availableResources[ResourceTypes.Food].ToString(); } catch { food.text = food.text; }
        try { money.text = MainManager.inventory.availableResources[ResourceTypes.Money].ToString(); } catch { money.text = money.text; }
        try { build.text = MainManager.inventory.availableResources[ResourceTypes.BuildingMaterials].ToString(); } catch { build.text = build.text; }
        try { human.text = MainManager.inventory.availableResources[ResourceTypes.Humans].ToString(); } catch { human.text = human.text; }
        try { wep1.text = MainManager.inventory.availableResources[ResourceTypes.WeaponShard].ToString(); } catch { wep1.text = wep1.text; }
        try { wep2.text = MainManager.inventory.availableResources[ResourceTypes.WeaponChunck].ToString(); } catch { wep2.text = wep2.text; }
        try { wep3.text = MainManager.inventory.availableResources[ResourceTypes.WeaponSlab].ToString(); } catch { wep3.text = wep3.text; }
        try { arm1.text = MainManager.inventory.availableResources[ResourceTypes.ArmorShard].ToString(); } catch { arm1.text = arm1.text; }
        try { arm2.text = MainManager.inventory.availableResources[ResourceTypes.ArmorChunck].ToString(); } catch { arm2.text = arm2.text; }
        try { arm3.text = MainManager.inventory.availableResources[ResourceTypes.ArmorSlab].ToString(); } catch { arm3.text = arm3.text; }

    }
}
