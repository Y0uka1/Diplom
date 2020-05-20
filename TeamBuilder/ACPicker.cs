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
        if (MainManager.teamBuilder.activePlaceholder.gameObject.transform.childCount < 2)
        {
            this.gameObject.transform.SetParent(MainManager.teamBuilder.activePlaceholder.transform);
            MainManager.teamBuilder.activePlaceholder.character = character;
        }
        else
        {
            var temp = MainManager.teamBuilder.activePlaceholder.gameObject.transform.GetChild(1);
            temp.SetParent(this.gameObject.transform.parent);
            temp.gameObject.transform.localPosition = new Vector3(0, 80, 0);
            this.gameObject.transform.SetParent(MainManager.teamBuilder.activePlaceholder.transform);
            MainManager.teamBuilder.activePlaceholder.character = character;

        }
        this.gameObject.transform.localPosition = new Vector3(0, 80, 0);

        MainManager.teamBuilder.activePlaceholder = null;
        MainManager.teamBuilder.PlaceholderActivate();
    }

    public virtual void OnSelect()
    {
        Placeholder place;

        if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && MainManager.teamBuilder.activePlaceholder != null)
        {
            MoveToPlaceHolder();
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && MainManager.teamBuilder.activePlaceholder == null)
        {

            MainManager.teamBuilder.activePlaceholder = place;
            MainManager.teamBuilder.PlaceholderActivate();
            Debug.Log("PlaceHolder");
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) != true)
        {
            MoveToPlaceHolder();
        }



    }
}
