using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernPicker : MonoBehaviour
{
    public ICharacterStats character;
    Button button;
    Image img;
    bool selected = false;


    void Start()
    {
        button = GetComponent<Button>();
        img = GetComponent<Image>();
     //   GameObject temp = new GameObject();
      //  border = temp.AddComponent(typeof(Image)) as Image;
     //   border.sprite = Resources.Load<Sprite>("Sprites/border");
      //  border.enabled = false;
      //  temp.transform.SetParent(this.gameObject.transform);
        button.onClick.AddListener(OnClick);    
    }

    void OnClick()
    {
        if (TownManager.tavernManager.curType != RelaxType.NULL)
        {
            if (!selected)
            {
                if (!MainManager.busyChars.Contains(character))
                {

                    if (TownManager.tavernManager.AddToList(character))
                    {
                        selected = true;
                        img.color = new Color(0, 100, 0);
                    }
                }

                //  border.enabled = true;
            }
            else
            {
                selected = false;
                img.color = new Color(0, 0, 0);
                TownManager.tavernManager.RemoveFromList(character);
            }
        }
    }
}
