using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorIMG : MonoBehaviour
{
    Image image;
    Button button;
    Text money;
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
                    Image stone = transform.GetChild(1).GetComponent<Image>();
                    stone.sprite = Resources.Load<Sprite>("Sprites/arm1");
                    stone.transform.GetChild(0).GetComponent<Text>().text = "5";
                    money = transform.GetChild(2).GetComponentInChildren<Text>();
                    money.text = "1000";
                    if (ResourcesManager.armorShard < 5 || ResourcesManager.money < 1000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break; 
                }

            case 1:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm1");
                    Image stone = transform.GetChild(1).GetComponent<Image>();
                    stone.sprite = Resources.Load<Sprite>("Sprites/arm2");
                    stone.transform.GetChild(0).GetComponent<Text>().text = "5";
                    money = transform.GetChild(2).GetComponentInChildren<Text>();
                    money.text = "3000";
                    if (ResourcesManager.armorChunck < 5 || ResourcesManager.money < 3000)
                        button.interactable = false;
                    else
                        button.interactable = true;
                    break;
                }
            case 2:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/Forge/Armor/arm2");
                    Image stone = transform.GetChild(1).GetComponent<Image>();
                    stone.sprite = Resources.Load<Sprite>("Sprites/arm3");
                    stone.transform.GetChild(0).GetComponent<Text>().text = "5";
                    money = transform.GetChild(2).GetComponentInChildren<Text>();
                    money.text = "5000";
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
