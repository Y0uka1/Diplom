using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeCharSelect : MonoBehaviour
{
    public delegate void DeactivateDel();
    public static event DeactivateDel Deactivate;
    DeactivateDel lambda;
    Button button;
    public ICharacterStats character;
    GameObject border;
    public void Initialize()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSelect);
        border = new GameObject("border");
        Image img = border.AddComponent(typeof(Image)) as Image;
        img.sprite = Resources.Load<Sprite>("Sprites/border");
        border.transform.SetParent(this.gameObject.transform);
        RectTransform rec = border.GetComponent<RectTransform>();
        rec.anchoredPosition = Vector2.zero;
        rec.localScale = Vector2.one;
        Deactivate += lambda = () => { border.GetComponent<Image>().enabled = false; };
        Deactivate.Invoke();
    }

    private void OnSelect()
    {
        Deactivate.Invoke();
        border.GetComponent<Image>().enabled = true;
        
        EquipmentManager.character = character;
        EquipmentManager.armor.ImageSwitch();
        EquipmentManager.weapon.ImageSwitch();
    }

    private void OnDestroy()
    {
        Deactivate -= lambda;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
