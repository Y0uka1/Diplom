using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharList : MonoBehaviour
{
    List<ICharacterStats> charList;
    void Start()
    {
        charList = MainManager.charSave.LoadData();
        foreach (var i in charList)
        {
            GameObject temp;
            temp = getPrefabPath(i.charClass);
            temp.transform.SetParent(this.transform);
        }
    }

    GameObject getPrefabPath(CharClassEnum type)
    {
        GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/CharacterSelectPrefab"));
        
        switch (type)
        {
            case CharClassEnum.Artorias:
            {
                 temp.AddComponent(typeof(ArtoriasPicker));
                    break;
            }

            case CharClassEnum.Lamia:
            {
                    temp.AddComponent(typeof(LamiaPicker));
                    break;
            }
        }
        return temp;
    }


}
