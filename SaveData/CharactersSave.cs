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
        Debug.Log("Save");
        characters = new List<ICharacterStats>() { new Artorias_Character(), new LamiaChar(), new LamiaChar(), new LamiaChar() };

        string json="";

        foreach(var i in characters)
        {
            json +=  i.SaveToString();
            json += SEPARATOR;
        }


        File.WriteAllText(Application.dataPath + "jjjjsave.txt", json);
    }

    public List<ICharacterStats> LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "jjjjsave.txt");
        string[] splitedJson = json.Split(new string[] { SEPARATOR }, System.StringSplitOptions.None) ;

        characters = new List<ICharacterStats>();
        
        Debug.Log(splitedJson);

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
