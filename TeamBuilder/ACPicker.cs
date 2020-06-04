using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class ACPicker : MonoBehaviour
{
    public Button button;
    public ICharacterStats character;
    public string name;

    public virtual void MoveToPlaceHolder()
    {
        if (TownManager.teamBuilder.activePlaceholder.gameObject.transform.childCount < 2)
        {
            this.gameObject.transform.SetParent(TownManager.teamBuilder.activePlaceholder.transform);
            TownManager.teamBuilder.activePlaceholder.character = character;
            TownManager.charList.charList.Remove(character);
        }
        else
        {
            var temp = TownManager.teamBuilder.activePlaceholder.gameObject.transform.GetChild(1);
            temp.SetParent(this.gameObject.transform.parent);
            temp.gameObject.transform.localPosition = new Vector3(0, 80, 0);
            this.gameObject.transform.SetParent(TownManager.teamBuilder.activePlaceholder.transform);
            TownManager.teamBuilder.activePlaceholder.character = character;
            TownManager.charList.charList.Remove(character);
            if(temp.gameObject.GetComponent<ACPicker>().character!=character)
            TownManager.charList.charList.Add(temp.gameObject.GetComponent<ACPicker>().character);
        }
        this.gameObject.transform.localPosition = new Vector3(0, 80, 0);

        TownManager.teamBuilder.activePlaceholder = null;
        TownManager.teamBuilder.PlaceholderActivate();
    }

    public virtual void OnSelect()
    {
        Placeholder place;

        if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && TownManager.teamBuilder.activePlaceholder != null)
        {
            MoveToPlaceHolder();
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && TownManager.teamBuilder.activePlaceholder == null)
        {

            TownManager.teamBuilder.activePlaceholder = place;
            TownManager.teamBuilder.PlaceholderActivate();
            Debug.Log("PlaceHolder");
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) != true)
        {
            MoveToPlaceHolder();
        }



    }
}
