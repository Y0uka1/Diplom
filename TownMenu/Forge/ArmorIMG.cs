using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorIMG : MonoBehaviour
{
    Image image;
    Button button;
    int level;
    public void Initialize()
    {
        image = GetComponent<Image>();
        
        button = transform.GetChild(0).GetComponent<Button>();


            transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/levelUP");
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Upgrade );
        
        ImageSwitch();
    }

    private void Upgrade()
    {
        
        switch (EquipmentManager.character.armorLevel)
        {
            case 0:
                ResourcesManager.armorShard -= 5;
                ResourcesManager.money -= 1000;
                break;
            case 1:
                ResourcesManager.armorChunck -= 5;
                ResourcesManager.money -= 3000;
                break;
            case 2:
                ResourcesManager.armorSlab -= 5;
                ResourcesManager.money -= 5000;
                break;
        }
        EquipmentManager.character.armorLevel++;
        ImageSwitch();
        MainManager.charSave.SaveData();
        ResourcesData.OnChange();
    }

    public void ImageSwitch()
    {
       
        switch (EquipmentManager.character.armorLevel)
        {
            case 0:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm0");
                    if (ResourcesManager.armorShard < 5 || ResourcesManager.money < 1000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break; 
                }

            case 1:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm1");
                    if (ResourcesManager.armorChunck < 5 || ResourcesManager.money < 3000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }
            case 2:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm2");
                    if (ResourcesManager.armorSlab < 5 || ResourcesManager.money < 5000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }
            case 3:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm3");
                        button.interactable = false;
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
