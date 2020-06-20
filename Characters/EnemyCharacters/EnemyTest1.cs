using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyTest1 : ICharacterStats
{
    public EnemyTest1():base(IDManager.GetID())
    {
        type = typeof(EnemyTest1GO);
        maxHealthPoints = 50 + (50 * LootManager.level) ;
        maxConcentrationPoints = 1;
        armor = 5 + (10 * LootManager.level);
        baseDamage = 10 + (15 * LootManager.level);
        baseSpeed = 13 + (5 * LootManager.level);
        charType = CharacterType.Enemy;
        charClass = CharClassEnum.Enemy;
        skill2Usage = 0;
        skill3Usage = 0;
        skill4Usage = 0;
        base.CurrentStatsInitialize();
    }


    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage + 15);
        MainManager.battleManager.target.LooseMorale(20);
        Debug.Log("skill 1");
    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage + 25);
        Debug.Log("skill 2");
    }

    public override void Skill_3()
    {
        foreach (var i in MainManager.playersTeam.team)
        {
            
            i?.TakeDamage(CurDamage + 5);
        }

        Debug.Log("skill 3");
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                  3,
                   temp.character = MainManager.battleManager.target,
                   () => { temp.character.CurDamage -= 10; },
                   null,
                   () => { temp.character.CurDamage += 10; }
                  );

        Debug.Log("skill 4");
    }

}
