﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharList : MonoBehaviour
{
   public List<ICharacterStats> charList;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    
    public void Initialize()
    {
       
       // {
            foreach (Transform i in this.gameObject.transform)
            {
                Object.Destroy(i.gameObject);
            }
             
            gameObject.transform.DetachChildren();
            if (status == ManagerStatus.Offline)
             {
            charList = MainManager.charSave.LoadData();
             }
        foreach (var i in charList)
            {
                GameObject temp;
                temp = getPrefab(i);

                temp.transform.SetParent(this.transform);
            }
            status = ManagerStatus.Online;
       // }
    }

    GameObject getPrefab(ICharacterStats chara)
    {
        GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/CharacterSelectPrefab"));
        
        switch (chara.charClass)
        {
            case CharClassEnum.Artorias:
            {
                    ArtoriasPicker picker = temp.AddComponent(typeof(ArtoriasPicker)) as ArtoriasPicker;
                    picker.character = chara;
                    
                    break;
            }

            case CharClassEnum.Lamia:
            {
                    LamiaPicker picker = temp.AddComponent(typeof(LamiaPicker)) as LamiaPicker;
                    picker.character = chara;
                    break;
            }
        }
        return temp;
    }


}
