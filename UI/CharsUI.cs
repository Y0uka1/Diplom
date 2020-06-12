using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharsUI : MonoBehaviour
{
    Button char1;
    Button char2;
    Button char3;
    Button char4;

    ICharacterStats chara;

    Text statsText;

    public void Initialize()
    {
        char1 = transform.GetChild(0).GetComponent<Button>();
        char2 = transform.GetChild(1).GetComponent<Button>();
        char3 = transform.GetChild(2).GetComponent<Button>();
        char4 = transform.GetChild(3).GetComponent<Button>();

        statsText = transform.GetChild(4).GetComponentInChildren<Text>();
        try
        {
            char1.GetComponent<Image>().sprite = Resources.Load<Sprite>(MainManager.playersTeam.team[0].avatarPath);
            char1.onClick.AddListener(() => { chara = MainManager.playersTeam.team[0]; StatsRefresh(); });
        }
        catch
        {
            char1.GetComponent<Image>().sprite=null;
        }
        try
        {
            char2.GetComponent<Image>().sprite = Resources.Load<Sprite>(MainManager.playersTeam.team[1].avatarPath);
            char2.onClick.AddListener(() => { chara = MainManager.playersTeam.team[1]; StatsRefresh(); });
        }
        catch
        {
            char2.GetComponent<Image>().sprite = null;
        }
        try { 
        char3.GetComponent<Image>().sprite = Resources.Load<Sprite>(MainManager.playersTeam.team[2].avatarPath);
            char3.onClick.AddListener(() => { chara = MainManager.playersTeam.team[2]; StatsRefresh(); });
        }
        catch
        {
            char3.GetComponent<Image>().sprite = null;
        }
        try
        {
            char4.GetComponent<Image>().sprite = Resources.Load<Sprite>(MainManager.playersTeam.team[3].avatarPath);
            char4.onClick.AddListener(() => { chara = MainManager.playersTeam.team[3]; StatsRefresh(); });
        }
        catch
        {
            char4.GetComponent<Image>().sprite = null;
        }
       
       
       
      
    }

    void StatsRefresh()
    {
        statsText.text = $"HP:{chara.CurHealthPoints}/{chara.maxHealthPoints}\t Armor:{chara.curArmor}/{chara.armor} \n" +
            $"CP:{chara.CurConcentrationPoints}/{chara.maxConcentrationPoints}\nDamage:{chara.CurDamage}/{chara.baseDamage}\nSpeed:{chara.curSpeed}/{chara.baseSpeed}" +
            $"Weapon:{chara.weaponLevel}\t Armor{chara.armorLevel}";
    }
}
