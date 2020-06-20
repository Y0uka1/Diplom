using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest2 : ICharacterStats
{
    public EnemyTest2() : base(IDManager.GetID())
    {
        type = typeof(EnemyTest2GO);
        maxHealthPoints = 150 + (100 * LootManager.level);
        maxConcentrationPoints = 1;
        armor = 10 + (15 * LootManager.level);
        baseDamage = 5 + (9 * LootManager.level);
        baseSpeed = 5 + (4 * LootManager.level);
        charType = CharacterType.Enemy;
        charClass = CharClassEnum.Enemy;
        skill2Usage = 0;
        skill3Usage = 0;
        skill4Usage = 0;

        base.CurrentStatsInitialize();
    }

    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage + 10);
        Debug.Log("skill 1");
    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage + 15);
        MainManager.battleManager.target.LooseMorale(20);
        Debug.Log("skill 2");
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                  3,
                   temp.character = MainManager.battleManager.target,
                   () => { temp.character.curSpeed -= (CurDamage/3) + 10; },
                   null,
                   () => { temp.character.curSpeed += (CurDamage / 3) +10; }
                  );
        MainManager.battleManager.target.TakeDamage(CurDamage + 8);
        Debug.Log("skill 3");
    }

    public override void Skill_4()
    {
        foreach (var i in MainManager.playersTeam.team)
        {
            if (i != null)
            {
               i.BuffAdd(
                 new BuffStruct(
                     2,
                      i,
                      () => { i.curArmor -= (CurDamage/4) + 5; },
                      null,
                      () => { i.curArmor += (CurDamage / 4) + 5; }
                     )
                 );
            }
        }

        Debug.Log("skill 4");
    }

}
