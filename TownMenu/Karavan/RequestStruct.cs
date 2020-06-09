using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RequestStruct 
{
    [SerializeField] public int money ;
    [SerializeField] public int weaponShard ;
    [SerializeField] public int weaponChunk ;
    [SerializeField] public int weaponSlab ;
    [SerializeField] public int armorShard ;
    [SerializeField] public int armorChunck;
    [SerializeField] public int armorSlab ;
    [SerializeField] public int humans ;
    [SerializeField] public int buildMaterials ;

    public void SaveData()
    {
        string tmp = JsonUtility.ToJson(this);
        Debug.Log(tmp);
        File.WriteAllText(Application.persistentDataPath + "Request.txt", tmp);
    }

    public void LoadData()
    {
        string json = "";
        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "Request.txt");
        }
        catch
        {
            SaveData();
        }
       
        JsonUtility.FromJsonOverwrite(json, this);

        Debug.Log($"{money} {weaponShard} {weaponChunk} {weaponSlab}");
    }

}
