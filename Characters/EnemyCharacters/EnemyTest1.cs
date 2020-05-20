using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyTest1 : ICharacterStats
{
    public EnemyTest1()
    {
        type = typeof(EnemyTest1GO);
        maxHealthPoints = 100;
        curHealthPoints = maxHealthPoints;
        maxConcentrationPoints = 100;
        armor = 10;
        baseDamage = 15;
        baseSpeed = 13;
        charType = CharacterType.Enemy;
        charClass = CharClassEnum.Enemy;
    }

  
}
