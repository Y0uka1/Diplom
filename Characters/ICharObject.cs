using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ICharObject :MonoBehaviour , ICharacterView
{
    public ICharacterStats character;
    public string prefabWay;
   

    #region view;
    public Sprite skill_1_Sprite { get; set; }
    public Sprite skill_2_Sprite { get; set; }
    public Sprite skill_3_Sprite { get; set; }
    public Sprite skill_4_Sprite { get; set; }
    public Sprite stand_Sprite { get; set; }
    public Sprite stand_Battle_Sprite { get; set; }
    public Sprite take_Damage_Sprite { get; set; }
    public Image skill_1_Image { get; set; }
    public Image skill_2_Image { get; set; }
    public Image skill_3_Image { get; set; }
    public Image skill_4_Image { get; set; }
    #endregion view;

    public void OnTurnChanges()
    {

    }
   

    public abstract void Initialize(ICharacterStats character);

}
