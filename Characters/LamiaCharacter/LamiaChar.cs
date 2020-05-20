using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LamiaChar : ICharacterStats
{
   //CharGO

    public bool skillSelected;

    public LamiaChar()
    {
        type = typeof(LamiaCharGO);
        typeString = type.ToString();
        maxHealthPoints = 100;
        curHealthPoints = maxHealthPoints;
        maxConcentrationPoints = 100;
        armor = 10;
        baseDamage = 30;
        baseSpeed = 13;
        charClass = CharClassEnum.Lamia;
    }

    
    public override void Skill_1()
    {

        Debug.Log("Lamia Skill 1 Executed");
        MainManager.battleManager.target.TakeDamage(16);

    }

    public override void Skill_2()
    {
        Debug.Log("Lamia Skill 2 Executed");
        MainManager.battleManager.target.TakeDamage(15);
    }

    public override void Skill_3()
    {
        Debug.Log("Lamia Skill 3 Executed");
        MainManager.battleManager.target.TakeDamage(14);
    }

    public override void Skill_4()
    {
        Debug.Log("Lamia Skill 4 Executed");
        MainManager.battleManager.target.TakeDamage(13);
    }

}
