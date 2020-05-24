using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIMG : MonoBehaviour
{
    Image image;
    Button button;
   public void Initialize()
    {
        image = GetComponent<Image>();
        
        button = transform.GetChild(0).GetComponent<Button>();
        if (EquipmentManager.character.weaponLevel < 3)
        {
            transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/levelUP");
            button.onClick.AddListener(Upgrade);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
        
        ImageSwitch();
    }

    private void Upgrade()
    {
        if (EquipmentManager.character.weaponLevel < 3)
        {
            EquipmentManager.character.weaponLevel++;
        }
        ImageSwitch();
        MainManager.charSave.SaveData();
    }

    public void ImageSwitch()
    {
        
        
        switch (EquipmentManager.character.weaponLevel)
        {
            case 0:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep0");
                    break;
                }

            case 1:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep1");
                    break;
                }
            case 2:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep2");
                    break;
                }
            case 3:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep3");
                    break;
                }
            default:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep1");
                    break;
                }
        }
    }
}
