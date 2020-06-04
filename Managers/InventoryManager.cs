using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager :MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    public Dictionary<ResourceTypes, int> availableResources;
    public void Initialize()
    {
        availableResources = new Dictionary<ResourceTypes, int>();
        availableResources.Add(ResourceTypes.Money, 0);
        availableResources.Add(ResourceTypes.Humans, 0);
        status = ManagerStatus.Online;
    }

    public void ResAdd(ResourceTypes type, int count)
    {
        availableResources[type]+=count;
    }

    public void ResRemove(ResourceTypes type, int count)
    {
        availableResources[type]-=count;
    }
   
}
