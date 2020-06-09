using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DridaCharacter : ICharacterStats
{
    public DridaCharacter() : base()
    {
        type = typeof(DridaCharGObject);
        typeString = type.ToString();
        maxHealthPoints = 50;
        maxConcentrationPoints = 150;
        armor = 10;
        baseDamage = 10;
        baseSpeed = 18;
        charClass = CharClassEnum.Drida;
        skill2Usage = 30;
        skill3Usage = 50;
        skill4Usage = 100;
        concentrationRegeneration = 25;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Ally;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        base.CurrentStatsInitialize();
    }

    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(15);
    }

    public override void Skill_2()
    {
        foreach(var i in MainManager.playersTeam.team)
        {
            i.CurHealthPoints += 5;
            MainManager.battleManager.BuffAdd(
             new BuffStruct(
                 2,
                  i,
                  () => { i.curArmor += 5; },
                  null,
                  () => { i.curArmor -= 5; }
                 )
             );
        }
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                 1,
                  temp.character = MainManager.battleManager.target,
                  () =>
                  {
                      temp.character.curSpeed -= 20;
                      temp.character.curDamage -= 10;
                  },
                  () => { temp.character.CurHealthPoints -= 1; },
                  () =>
                  {
                      temp.character.curSpeed += 20;
                      temp.character.curDamage += 10;
                  }
                 );

        MainManager.battleManager.BuffAdd(temp);
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct();
         temp = new BuffStruct(
                 2,
                   temp.character = MainManager.battleManager.target,
                  () => { MainManager.battleManager.target.curSpeed -= 5; },
                  null,
                  () =>
                  {
                      temp.character.curSpeed += 5;
                      temp.character.TakeDamage(50);
                  }
                 );
       MainManager.battleManager.BuffAdd(temp);
        CurConcentrationPoints -= skill4Usage;
    }
}
