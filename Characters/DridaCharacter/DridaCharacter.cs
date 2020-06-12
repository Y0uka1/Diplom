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
        skill2Usage = 40;
        skill3Usage = 50;
        skill4Usage = 100;
        concentrationRegeneration = 25;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Enemy;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        skill1Name = "Удар посохом";
        skill2Name = "Губительные миазмы";
        skill3Name = "Сковывающая лоза";
        skill4Name = "Взрывные споры";

        avatarPath = "Sprites/Characters/Avatars/DridaAvatar";

        base.CurrentStatsInitialize();
    }

    public DridaCharacter(int id) : base(id)
    {
        type = typeof(DridaCharGObject);
        typeString = type.ToString();
        maxHealthPoints = 50;
        maxConcentrationPoints = 150;
        armor = 10;
        baseDamage = 10;
        baseSpeed = 18;
        charClass = CharClassEnum.Drida;
        skill2Usage = 40;
        skill3Usage = 50;
        skill4Usage = 100;
        concentrationRegeneration = 25;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Enemy;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        skill1Name = "Удар посохом";
        skill2Name = "Губительные миазмы";
        skill3Name = "Сковывающая лоза";
        skill4Name = "Взрывные споры";

        avatarPath = "Sprites/Characters/Avatars/DridaAvatar";

        base.CurrentStatsInitialize();
    }

    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage+15 + (10*weaponLevel));
    }

    public override void Skill_2()
    {
        foreach(var i in MainManager.playersTeam.team)
        {
            
            i.BuffAdd(
             new BuffStruct(
                 4,
                  i,
                  () => { i.curArmor -= 5+(5*weaponLevel); },
                  () => { i.CurHealthPoints -= 10 * (10 * weaponLevel); },
                  () => { i.curArmor += 5 + (5 * weaponLevel); }
                 )
             );
        }
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct();
        temp = new BuffStruct(
                 2,
                  temp.character = MainManager.battleManager.target,
                  () =>
                  {
                      temp.character.curSpeed -= 20+(20*weaponLevel);
                      temp.character.CurDamage -= 10+(10*weaponLevel);
                  },
                  () => { temp.character.CurHealthPoints -= 1; },
                  () =>
                  {
                      temp.character.curSpeed += 20 + (20 * weaponLevel);
                      temp.character.CurDamage += 10 + (10 * weaponLevel);
                  }
                 );

        temp.character.BuffAdd(temp);
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct();
         temp = new BuffStruct(
                 2,
                   temp.character = MainManager.battleManager.target,
                   null,
                  null,
                  () =>
                  {
                      temp.character.TakeDamage(60+(60*weaponLevel));
                  }
                 );
        temp.character.BuffAdd(temp);
        CurConcentrationPoints -= skill4Usage;
    }
}
