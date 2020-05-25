using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourcesData : ScriptableObject
{
    [SerializeField] public  int money = 0;
    [SerializeField] public  int weaponShard = 0;
    [SerializeField] public  int weaponChunk = 0;
    [SerializeField] public  int weaponSlab = 0;
    [SerializeField] public  int armorShard = 0;
    [SerializeField] public  int armorChunck = 0;
    [SerializeField] public  int armorSlab = 0;
    [SerializeField] public  int humans = 0;
    [SerializeField] public  int buildMaterials = 0;

    

    public void SaveData()
    {
        string tmp = JsonUtility.ToJson(this);
        File.WriteAllText(Application.dataPath + "townResources.txt", tmp);
    }

    public void LoadData()
    {
      ResourcesData resData = ScriptableObject.CreateInstance(typeof(ResourcesData)) as ResourcesData;
        string json = File.ReadAllText(Application.dataPath + "townResources.txt");
        JsonUtility.FromJsonOverwrite(json, resData);


        money = resData.money;
        weaponChunk = resData.weaponChunk;
        weaponShard = resData.weaponShard;
        weaponSlab = resData.weaponSlab;
        armorShard = resData.armorShard;
        armorChunck = resData.armorChunck;
        armorSlab = resData.armorSlab;
        humans = resData.humans;
        buildMaterials = resData.buildMaterials;
    }
}
