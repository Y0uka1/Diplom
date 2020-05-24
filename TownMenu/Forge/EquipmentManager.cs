using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static WeaponIMG weapon;
    public static ArmorIMG armor;
    GameObject artifact1;
    GameObject artifact2;
    GameObject artifact3;
    GameObject artifact4;

    public static  ICharacterStats character;

   

    public void Initialize()
    {
        weapon = FindObjectOfType<WeaponIMG>();
        weapon.Initialize();
        armor = FindObjectOfType<ArmorIMG>();
        armor.Initialize();

    }
    
       
    
}
