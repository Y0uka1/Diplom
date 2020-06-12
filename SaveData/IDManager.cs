using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class IDManager
{
   static int? id;

    public static void SaveData()
    {
        if(id!=null)
        File.WriteAllText(Application.persistentDataPath + "lastID.txt", id.ToString());
        else
        {
            id = 0;
            File.WriteAllText(Application.persistentDataPath + "lastID.txt", id.ToString());
        }
    }

    public static void LoadData()
    {
        try
        {
            id = Convert.ToInt32(File.ReadAllText(Application.persistentDataPath + "lastID.txt"));
        }catch
        {
            SaveData();
        }
    }

    public static int GetID()
    {
        int Id = (int)id++;
        SaveData();
        return Id;
    }
}
