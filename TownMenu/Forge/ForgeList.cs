using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeList : MonoBehaviour
{
    public List<ICharacterStats> charList;
   
    public void Initialize()
    {
        EquipmentManager.character = null;
        foreach (Transform i in this.gameObject.transform)
        {
            Object.Destroy(i.gameObject);
        }
        Debug.Log(gameObject.transform.childCount);
        gameObject.transform.DetachChildren();

        charList = MainManager.charSave.LoadData();
        foreach (var i in charList)
        {
            GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/CharacterSelectPrefab"));
            ForgeCharSelect select = temp.AddComponent(typeof(ForgeCharSelect)) as ForgeCharSelect;
            select.character = i;
            select.Initialize();
            temp.transform.SetParent(this.transform);
        }
        EquipmentManager.character = charList[0];
    }

   
}
