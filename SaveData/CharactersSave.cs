using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CharactersSave : ScriptableObject
{
    const string SEPARATOR = "SEPARATOR";
    [SerializeField] List<ICharacterStats> characters;
    

    public void SaveData()
    {
        //characters = new List<ICharacterStats>() { new LamiaChar(), new Artorias_Character(), new Artorias_Character(), new LamiaChar() };

        string json="";

        foreach(var i in characters)
        {
            json +=  i.SaveToString();
            json += SEPARATOR;
        }


        File.WriteAllText(Application.persistentDataPath + "jjjjsave.txt", json);
    }

    public List<ICharacterStats> LoadData()
    {
        string json = "";

        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "jjjjsave.txt");
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
}
