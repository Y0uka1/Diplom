using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernList : MonoBehaviour
{
    private void Start()
    {
        
    }

    public List<ICharacterStats> charList;
    public Dictionary<ICharacterStats,GameObject> charListGO;
    public void GetList()
    {
        charListGO = new Dictionary<ICharacterStats, GameObject>();
        foreach (Transform i in this.gameObject.transform)
        {
            Object.Destroy(i.gameObject);
        }
        //    Debug.Log(gameObject.transform.childCount);
        gameObject.transform.DetachChildren();

        charList = TownManager.charList.charList;
        foreach (var i in charList)
        {
            GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/CharacterSelectPrefab"));
            TavernPicker select = temp.AddComponent(typeof(TavernPicker)) as TavernPicker;
            select.character = i;     
            temp.transform.SetParent(this.transform);
            charListGO.Add(i,temp);
        }
    }
}
