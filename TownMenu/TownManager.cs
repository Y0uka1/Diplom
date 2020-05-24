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

    public static void Initialize()
    {
        forgeList = FindObjectOfType<ForgeList>();
        equipmentManager = FindObjectOfType<EquipmentManager>();
        charList = FindObjectOfType<CharList>();
        teamBuilder = ScriptableObject.CreateInstance(typeof(TeamBuilder)) as TeamBuilder;
        
        mapManager = ScriptableObject.CreateInstance(typeof(MapManager)) as MapManager;


    }
}
