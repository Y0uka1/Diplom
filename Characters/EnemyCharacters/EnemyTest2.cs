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
        maxConcentrationPoints = 100;
        armor = 7;
        baseDamage = 25;
        baseSpeed = 13;
        charType = CharacterType.Enemy;
        charClass = CharClassEnum.Enemy;
        skill2Usage = 0;
        skill3Usage = 0;
        skill4Usage = 0;

        base.CurrentStatsInitialize();
    }

    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(10);
        Debug.Log("skill 1");
    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.TakeDamage(15);
        MainManager.battleManager.target.LooseMorale(20);
        Debug.Log("skill 2");
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                  3,
                   temp.character = MainManager.battleManager.target,
                   () => { temp.character.curSpeed -= 10; },
                   null,
                   () => { temp.character.curSpeed += 10; }
                  );
        MainManager.battleManager.target.TakeDamage(8);
        Debug.Log("skill 3");
    }

    public override void Skill_4()
    {
        foreach (var i in MainManager.playersTeam.team)
        {
            MainManager.battleManager.BuffAdd(
             new BuffStruct(
                 2,
                  i,
                  () => { i.curArmor -= 5; },
                  null,
                  () => { i.curArmor += 5; }
                 )
             );
        }

        Debug.Log("skill 4");
    }

}
