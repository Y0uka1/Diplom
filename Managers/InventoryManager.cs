using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager :MonoBehaviour, IManager
{
    public event Action OnLootGet;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    public Dictionary<ResourceTypes, int> availableResources;
    public Dictionary<ResourceTypes, int> tempResources;
    public void Initialize()
    {
        availableResources = new Dictionary<ResourceTypes, int>();
        tempResources = new Dictionary<ResourceTypes, int>();
        availableResources.Add(ResourceTypes.Money, 0);
        availableResources.Add(ResourceTypes.Humans, 0);
        status = ManagerStatus.Online;
    }

    public void ResAdd(ResourceTypes type, int count)
    {
        try
        {
            tempResources[type] += count;
        }
        catch
        {
            tempResources.Add(type, count);
        }
    }

    public void ResRemove(ResourceTypes type, int count)
    {
        tempResources[type]-=count;
    }

    public void OnLootAdded()
    {
        GameObject panel = Instantiate(Resources.Load<GameObject>("Prefabs/LootPanel"));
        panel.transform.SetParent(GameObject.Find("LevelUI").transform);
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,1);
        foreach(var i in tempResources)
        {
            if (i.Value != 0)
            {
                GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/LootedItem"));
                temp.GetComponent<LootedItem>().Initialize(i.Key, i.Value);
                temp.transform.SetParent(panel.transform.GetChild(1).GetChild(0).GetChild(0));
            }
        }
        panel.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            foreach (var i in MainManager.inventory.tempResources)
            {
                try { 
                MainManager.inventory.availableResources[i.Key] += i.Value;
                }
                catch
                {
                    availableResources.Add(i.Key, i.Value);
                }
            }
            tempResources.Clear();
            OnLootGet.Invoke();
            panel.GetComponentInChildren<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            Destroy(panel);
            
        });
        
    }
}
