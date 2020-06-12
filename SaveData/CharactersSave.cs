using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CharactersSave : ScriptableObject
{
    const string SEPARATOR = "SEPARATOR";
    [SerializeField] public List<ICharacterStats> characters;
    
    public void Initialize()
    {
        characters = new List<ICharacterStats>();
    }

    public void SaveData()
    {
        if (characters.Count <= 0 || characters==null)
        {
           
            characters.Add(new Artorias_Character(IDManager.GetID()));
            characters.Add(new LamiaChar(IDManager.GetID()));
        }

        string json="";

        foreach(var i in characters)
        {
            json +=  i.SaveToString();
            json += SEPARATOR;
        }


        File.WriteAllText(Application.persistentDataPath + "Characters.txt", json);
    }

    public List<ICharacterStats> LoadData()
    {
        Debug.Log(Application.persistentDataPath);
        string json = "";

        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "Characters.txt");
        }
        catch
        {
            SaveData();
        }
        string[] splitedJson = json.Split(new string[] { SEPARATOR }, System.StringSplitOptions.None) ;

        characters = new List<ICharacterStats>();
        
     //   Debug.Log(splitedJson);

       foreach(string i in splitedJson)
       {
            if (i != "") {
                CharClassEnum typeEnum = (CharClassEnum)Enum.Parse(typeof(CharClassEnum) , (i.Substring(i.IndexOf("charClass")+11,1)));
               
                System.Type type = Tools.EnumToCharClass(typeEnum);
                //var character = Activator.CreateInstance(type);
                ICharacterStats character = JsonUtility.FromJson(i,type) as ICharacterStats;
                characters.Add(character);
            }
       }
        return characters;
    }

    public static void AddChar(ICharacterStats chara)
    {
        MainManager.charSave.characters.Add(chara);
        MainManager.charSave.SaveData();
    }

    public static void RemoveChar (ICharacterStats chara)
    {
        MainManager.charSave.characters.Remove(chara);
        MainManager.charSave.SaveData();
    }
}
