using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest2 : ICharacterStats
{
    public EnemyTest2()
    {
        type = typeof(EnemyTest2GO);
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
