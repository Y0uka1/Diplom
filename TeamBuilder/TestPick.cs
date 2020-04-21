using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPick : MonoBehaviour
{
    Button button;
    Artorias_Character character;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        character = new Artorias_Character();
    }

    public void OnSelect()
    {

       // TeamBuilder.tempCharacter = new TestCharacter();
        Placeholder place;
        /*if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) != true) {
            Debug.Log("Empty");
            if (TeamBuilder.activePlaceholder.gameObject.transform.childCount < 1)
            {
                this.gameObject.transform.SetParent(TeamBuilder.activePlaceholder.transform);
            }
            else
            {
                var temp = TeamBuilder.activePlaceholder.gameObject.transform.GetChild(0);
                temp.SetParent(this.gameObject.transform.parent);
                temp.gameObject.transform.localPosition = new Vector3(0, 80, 0);
                this.gameObject.transform.SetParent(TeamBuilder.activePlaceholder.transform);
            }
            this.gameObject.transform.localPosition = new Vector3(0, 80, 0);
            TeamBuilder.activePlaceholder.placeholderImage.color = Color.white;
            TeamBuilder.activePlaceholder = null;
        }
        else 
        {

            TeamBuilder.activePlaceholder = place;
            Debug.Log("PlaceHolder");
        }*/

        if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && TeamBuilder.activePlaceholder!=null)
        {
            MoveToPlaceHolder();
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) == true && TeamBuilder.activePlaceholder == null)
        {

            TeamBuilder.activePlaceholder = place;
            TeamBuilder.PlaceholderActivate();
            Debug.Log("PlaceHolder");
        }
        else if (gameObject.transform.parent.TryGetComponent<Placeholder>(out place) != true)
        {
            MoveToPlaceHolder();
        }



    }

    private void MoveToPlaceHolder()
    {
        if (TeamBuilder.activePlaceholder.gameObject.transform.childCount < 2)
        {
            this.gameObject.transform.SetParent(TeamBuilder.activePlaceholder.transform);
            TeamBuilder.activePlaceholder.character = character;
        }
        else
        {
            var temp = TeamBuilder.activePlaceholder.gameObject.transform.GetChild(1);
            temp.SetParent(this.gameObject.transform.parent);
            temp.gameObject.transform.localPosition = new Vector3(0, 80, 0);
            this.gameObject.transform.SetParent(TeamBuilder.activePlaceholder.transform);
            TeamBuilder.activePlaceholder.character = character;

        }
        this.gameObject.transform.localPosition = new Vector3(0, 80, 0);
        
        TeamBuilder.activePlaceholder = null;
        TeamBuilder.PlaceholderActivate();
    }
}
