using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICharacterView
{
    Sprite skill_1_Sprite { get; set; }
    Sprite skill_2_Sprite { get; set; }
    Sprite skill_3_Sprite { get; set; }
    Sprite skill_4_Sprite { get; set; }
    Sprite stand_Sprite { get; set; }
    Sprite stand_Battle_Sprite { get; set; }
    Sprite take_Damage_Sprite { get; set; }


    Image skill_1_Image { get; set; }
    Image skill_2_Image { get; set; }
    Image skill_3_Image { get; set; }
    Image skill_4_Image { get; set; }


}
