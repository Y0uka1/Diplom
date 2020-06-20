using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour, ISectionEventType
{
    public GameObject interactObject { get; set ; }
    public bool isFinded { get ; set ; }
    public bool isActivated { get ; set ; }

    public void Initialize()
    {
        
    }

    public void OnInteract()
    {
      
    }

    public void TorchAndMoraleLowering()
    {
       
    }

    public void TriggerEntered()
    {
        ResourcesData.SaveData();
        MainManager.charSave.SaveData();
        LootManager.LootBag();
        GameObject panel = Instantiate(Resources.Load<GameObject>("Prefabs/LootPanel"));
        panel.transform.SetParent(GameObject.Find("LevelUI").transform);
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1);
        foreach (var i in MainManager.inventory.tempResources)
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
                try
                {
                    MainManager.inventory.availableResources[i.Key] += i.Value;
                }
                catch
                {
                    MainManager.inventory.availableResources.Add(i.Key, i.Value);
                }
            }
            MainManager.inventory.tempResources.Clear();
            MainManager.LoadLevel("Town");
            panel.GetComponentInChildren<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            Destroy(panel);

        });

        //
    }

    
}
