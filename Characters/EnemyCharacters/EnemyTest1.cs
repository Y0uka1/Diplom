using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest1 : ICharacterStats
{
    public Type type { get; set; } = typeof(EnemyTest1GO);
    public ICharObject link { get; set; }
    public double maxHealthPoints { get; set; }
    public double curHealthPoints { get; set; }
    public double maxConcentrationPoints { get; set; }
    public double curConcentrationPoints { get; set; }
    public double armor { get; set; }
    public double curArmor { get; set; }
    public double baseDamage { get; set; }
    public double curDamage { get; set; }
    public CharacterType charType { get; set; }
    public double baseSpeed { get; set; }
    public double curSpeed { get; set; }
    public double morale { get; set; }

    public EnemyTest1()
    {
        maxHealthPoints = 100;
        curHealthPoints = maxHealthPoints;
        maxConcentrationPoints = 100;
        armor = 10;
        baseDamage = 15;
        baseSpeed = 13;
        charType = CharacterType.Enemy;
    }

    public void Death()
    {
       
    }

    public void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(16);
    }

    public void Skill_2()
    {
        MainManager.battleManager.target.TakeDamage(16);
    }

    public void Skill_3()
    {
        MainManager.battleManager.target.TakeDamage(16);
    }

    public void Skill_4()
    {
        MainManager.battleManager.target.TakeDamage(16);
    }

    public void TakeDamage(double dmg)
    {
        curHealthPoints -= (dmg - curArmor);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
