using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesData
{
    [SerializeField] public  int money = 1;
    [SerializeField] public  int weaponShard = 1;
    [SerializeField] public  int weaponChunk = 1;
    [SerializeField] public  int weaponSlab = 1;
    [SerializeField] public  int armorShard = 1;
    [SerializeField] public  int armorChunck = 1;
    [SerializeField] public  int armorSlab = 1;
    [SerializeField] public  int humans = 1;
    [SerializeField] public  int buildMaterials = 1;
    [SerializeField] public int glory = 500;

    

    public static void SaveData()
    {
        string tmp = JsonUtility.ToJson(new ResourcesData());
        File.WriteAllText(Application.persistentDataPath + "townResources.txt", tmp);
    }

    public static void LoadData()
    {
        string json="";
        try
        {
             json = File.ReadAllText(Application.persistentDataPath + "townResources.txt");
        }
        catch
        {
            SaveData();
        }
        ResourcesData resData = new ResourcesData();
       
        JsonUtility.FromJsonOverwrite(json, resData);


        ResourcesManager.money = resData.money;
        ResourcesManager.weaponChunk = resData.weaponChunk;
        ResourcesManager.weaponShard = resData.weaponShard;
        ResourcesManager.weaponSlab = resData.weaponSlab;
        ResourcesManager.armorShard = resData.armorShard;
        ResourcesManager.armorChunck = resData.armorChunck;
        ResourcesManager.armorSlab = resData.armorSlab;
        ResourcesManager.humans = resData.humans;
        ResourcesManager.buildMaterials = resData.buildMaterials;
        ResourcesManager.glory = resData.glory;
    }
}
