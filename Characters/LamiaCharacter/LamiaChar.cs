using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LamiaChar : ICharacterStats
{
   //CharGO

    public bool skillSelected;

    public LamiaChar():base()
    {
        type = typeof(LamiaCharGO);
        typeString = type.ToString();
        maxHealthPoints = 100;
        maxConcentrationPoints = 100;
        armor = 3;
        baseDamage = 30;
        baseSpeed = 13;
        charClass = CharClassEnum.Lamia;
        skill2Usage = 10;
        skill3Usage = 15;
        skill4Usage = 20;
        concentrationRegeneration = 5;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Ally;
        skill3Target = CharacterType.Ally;
        skill4Target = CharacterType.Ally;

        base.CurrentStatsInitialize();
    }

    
    public override void Skill_1()
    {

        MainManager.battleManager.target.TakeDamage(10);

    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.CurHealthPoints += 20;
        MainManager.battleManager.target.LooseMorale(-10);
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                   3,
                   temp.character = MainManager.battleManager.target,
                    () => { temp.character.curSpeed += 10; },
                    () => { temp.character.LooseMorale(-5); },
                    () => { temp.character.curSpeed -= 10; }
                   );

        MainManager.battleManager.BuffAdd(temp);
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                  3,
                   temp.character = MainManager.battleManager.target,
                   () => { temp.character.curDamage += 20; },
                   () => { temp.character.curHealthPoints -= 2; },
                   () => { temp.character.curDamage -= 20; }
                  );

        MainManager.battleManager.BuffAdd(temp);
        CurConcentrationPoints -= skill4Usage;
    }

}
