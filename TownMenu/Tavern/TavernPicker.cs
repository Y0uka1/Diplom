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
        img.sprite = Resources.Load<Sprite>(character.avatarPath);
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
            int price = 0;
            ACSwitch temp;
            switch (TownManager.tavernManager.curType)
            {
                case RelaxType.Bar:
                    price = SwitchToBar.price;
                    temp = FindObjectOfType<SwitchToBar>();
                    break;

                case RelaxType.Casino:
                    price = SwitchToCasino.price;
                    temp = FindObjectOfType<SwitchToCasino>();
                    break;

                case RelaxType.Bordel:
                    price = SwitchToBordel.price;
                    temp = FindObjectOfType<SwitchToBordel>();
                    break;

                case RelaxType.Room:
                    price = SwitchToRoom.price;
                    temp = FindObjectOfType<SwitchToRoom>();
                    break;
                default:
                    temp = temp = FindObjectOfType<SwitchToBar>();
                    break;
            }
            if (!selected)
            {
                if (!MainManager.busyChars.Contains(character))
                {

                    if (TownManager.tavernManager.AddToList(character))
                    {
                        selected = true;
                        img.color = new Color(0, 100, 0);
                        
                        TownManager.tavernManager.totalPrice += price;
                        temp.CheckPrice();
                        Debug.Log(TownManager.tavernManager.totalPrice);
                    }
                }

                //  border.enabled = true;
            }
            else
            {
                selected = false;
                img.color = new Color(255, 255, 255);
                TownManager.tavernManager.totalPrice -= price;
                temp.CheckPrice();
                TownManager.tavernManager.RemoveFromList(character);

            }
        }
    }
}
