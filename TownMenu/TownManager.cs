﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public static EquipmentManager equipmentManager;
    public static TeamBuilder teamBuilder;
    public static ForgeList forgeList;
    public static MapManager mapManager;
    public static CharList charList;
    public static ResourcesCountUI resourcesUI;
    public static TavernManager tavernManager;
    public static KaravanManager karavanManager;
    public static void Initialize()
    {
        forgeList = FindObjectOfType<ForgeList>();
        equipmentManager = FindObjectOfType<EquipmentManager>();
        charList = FindObjectOfType<CharList>();
        teamBuilder = ScriptableObject.CreateInstance(typeof(TeamBuilder)) as TeamBuilder;
        
        mapManager = ScriptableObject.CreateInstance(typeof(MapManager)) as MapManager;

        tavernManager = ScriptableObject.CreateInstance(typeof(TavernManager)) as TavernManager;

        karavanManager = ScriptableObject.CreateInstance(typeof(KaravanManager)) as KaravanManager;

       // ResourcesData.LoadData();
        resourcesUI = FindObjectOfType<ResourcesCountUI>();
        resourcesUI.Initialize();
    }
}
