using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorIMG : MonoBehaviour
{
    Image image;
    Button button;
    public void Initialize()
    {
        image = GetComponent<Image>();
        
        button = transform.GetChild(0).GetComponent<Button>();

        if (EquipmentManager.character.armorLevel < 3)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/levelUP");
            button.onClick.AddListener(Upgrade );
        }
        else
        {
            button.gameObject.SetActive(false);
        }
        ImageSwitch();
    }

    private void Upgrade()
    {
        if (EquipmentManager.character.armorLevel < 3)
        {
            EquipmentManager.character.armorLevel++;
        }
        ImageSwitch();
        MainManager.charSave.SaveData();
    }

    public void ImageSwitch()
    {
       
        switch (EquipmentManager.character.armorLevel)
        {
            case 0:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm0");
                    break; 
                }

            case 1:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm1");
                    break;
                }
            case 2:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm2");
                    break;
                }
            case 3:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm3");
                    break;
                }
            default:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm1");
                    break;
                }
        }
    }
}
