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
            transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/levelUP");
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Upgrade);

        ImageSwitch();
    }

    private void Upgrade()
    {
        
        switch (EquipmentManager.character.weaponLevel)
        {
            case 0:
                ResourcesManager.weaponShard -= 5;
                ResourcesManager.money -= 1000;
                break;
            case 1:
                ResourcesManager.weaponChunk -= 5;
                ResourcesManager.money -= 3000;
                break;
            case 2:
                ResourcesManager.weaponSlab -= 5;
                ResourcesManager.money -= 5000;
                break;
        }
        EquipmentManager.character.weaponLevel++;
        ImageSwitch();
        MainManager.charSave.SaveData();
        ResourcesData.OnChange();
    }

    public void ImageSwitch()
    {
        
        
        switch (EquipmentManager.character.weaponLevel)
        {
            case 0:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep0");
                    if (ResourcesManager.weaponShard < 5 || ResourcesManager.money < 1000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }

            case 1:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep1");
                    if (ResourcesManager.weaponChunk < 5 || ResourcesManager.money < 3000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }
            case 2:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep2");
                    if (ResourcesManager.weaponSlab < 5 || ResourcesManager.money < 5000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }
            case 3:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Weapon/wep3");
                    button.interactable = false;
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
