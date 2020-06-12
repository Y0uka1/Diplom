using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootedItem : MonoBehaviour
{

    Image image;
    Text text;

    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<Text>();
    }

    public void Initialize(ResourceTypes type, int count)
    {
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<Text>();
        switch (type)
        {
            case ResourceTypes.Money:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/money");
                    break;   
                }
            case ResourceTypes.BuildingMaterials:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/build");
                    break;
                }
            case ResourceTypes.ArmorShard:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/arm1");
                    break;
                }
            case ResourceTypes.ArmorChunck:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/arm2");
                    break;
                }
            case ResourceTypes.ArmorSlab:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/arm3");
                    break;
                }
            case ResourceTypes.WeaponShard:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/wep1");
                    break;
                }
            case ResourceTypes.WeaponChunck:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/wep2");
                    break;
                }
            case ResourceTypes.WeaponSlab:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/wep3");
                    break;
                }
            case ResourceTypes.Glory:
                {
                    image.sprite = Resources.Load<Sprite>("Sprites/glory");
                    break;
                }
        }
        text.text = count.ToString();
    }
    
}
