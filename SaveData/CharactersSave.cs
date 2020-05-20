using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharactersSave : ScriptableObject
{
    [SerializeField] List<ICharacterStats> characters;
    

    public void SaveData()
    {
        Debug.Log("Save");
        characters = new List<ICharacterStats>() { new Artorias_Character(), new LamiaChar() };

        string json="";

        foreach(var i in characters)
        {
            json += i.SaveToString();
        }


        File.WriteAllText(Application.dataPath + "jjjjsave.txt", json);
    }
}
