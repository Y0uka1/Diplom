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
        skill2Usage = 20;
        skill3Usage = 30;
        skill4Usage = 50;
        concentrationRegeneration = 20;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Ally;
        skill3Target = CharacterType.Ally;
        skill4Target = CharacterType.Ally;

        avatarPath = "Sprites/Characters/Avatars/nunAvatar";

        base.CurrentStatsInitialize();
    }

    public LamiaChar(int id) : base(id)
    {
        type = typeof(LamiaCharGO);
        typeString = type.ToString();
        maxHealthPoints = 100;
        maxConcentrationPoints = 100;
        armor = 3;
        baseDamage = 30;
        baseSpeed = 13;
        charClass = CharClassEnum.Lamia;
        skill2Usage = 20;
        skill3Usage = 30;
        skill4Usage = 50;
        concentrationRegeneration = 20;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Ally;
        skill3Target = CharacterType.Ally;
        skill4Target = CharacterType.Ally;

        avatarPath = "Sprites/Characters/Avatars/nunAvatar";

        base.CurrentStatsInitialize();
    }


    public override void Skill_1()
    {

        MainManager.battleManager.target.TakeDamage(CurDamage + 10 + (10*weaponLevel));

    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.CurHealthPoints += 15+(10*weaponLevel);
        MainManager.battleManager.target.LooseMorale(-10);
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        foreach(var i in MainManager.playersTeam.team)
        {
            if (i != null)
            {
                i.CurHealthPoints += 7 + (7 * weaponLevel);
                BuffStruct temp = new BuffStruct();//7 5
                temp = new BuffStruct(
                           3,
                           i,
                            () => { i.curSpeed += 5 + (5 * weaponLevel); },
                            null,
                            () => { i.curSpeed -= 5 + (5 * weaponLevel); }
                           );
                i.BuffAdd(temp);
            }
        }
       

        
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                  3,
                   temp.character = MainManager.battleManager.target,
                   () => { temp.character.CurDamage += 20+(20*weaponLevel); },
                   () => { temp.character.curHealthPoints -= 5+(5*weaponLevel); },
                   () => { temp.character.CurDamage -= 20 + (20 * weaponLevel); }
                  );

        temp.character.BuffAdd(temp);
        CurConcentrationPoints -= skill4Usage;
    }

}
