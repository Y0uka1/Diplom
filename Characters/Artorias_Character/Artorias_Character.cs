using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Artorias_Character : ICharacterStats
{
    public bool skillSelected;
    ManagerStatus status = ManagerStatus.Offline;
    

    public Artorias_Character():base()
    {
        charClass = CharClassEnum.Artorias;
        type = typeof(ArtoriasCharGObject);
        typeString = type.ToString();
        maxHealthPoints = 100;
        maxConcentrationPoints = 100;
        armor = 7;
        baseDamage = 15;
        skill2Usage = 20;
        skill3Usage = 40;
        baseSpeed = 10;
        skill4Usage = (float)maxConcentrationPoints;
        concentrationRegeneration = 15;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Enemy;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        skill1Name = "Бросок Ножа";
        skill2Name = "Проникающий Клинок";
        skill3Name = "Кульбит И Удар";
        skill4Name = "Кровавая Баня";

        avatarPath = "Sprites/Characters/Avatars/plutAvatar";

        base.CurrentStatsInitialize();
    }

    public Artorias_Character(int id) : base(id)
    {
        charClass = CharClassEnum.Artorias;
        type = typeof(ArtoriasCharGObject);
        typeString = type.ToString();
        maxHealthPoints = 100;
        maxConcentrationPoints = 100;
        armor = 7;
        baseDamage = 15;
        skill2Usage = 20;
        skill3Usage = 40;
        baseSpeed = 10;
        skill4Usage = (float)maxConcentrationPoints;
        concentrationRegeneration = 15;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Enemy;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        skill1Name = "Бросок Ножа";
        skill2Name = "Проникающий Клинок";
        skill3Name = "Кульбит И Удар";
        skill4Name = "Кровавая Баня";

        avatarPath = "Sprites/Characters/Avatars/plutAvatar";

        base.CurrentStatsInitialize();
    }



    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(CurDamage + 25+(25*weaponLevel));
    }

    public override void Skill_2()
    {
        MainManager.battleManager.target.CurHealthPoints-=(25 + (15 * weaponLevel));
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        double damage = CurDamage + 20 + (20 * weaponLevel);
        if (this.curSpeed > MainManager.battleManager.target.curSpeed)
            damage *= 2;
        MainManager.battleManager.target.TakeDamage(damage);
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {

        BuffStruct temp = new BuffStruct(); 
        temp = new BuffStruct(
                999,
                 temp.character = MainManager.battleManager.target,
                 () => { temp.character.CurHealthPoints -= temp.character.maxHealthPoints / 4;
                     temp.character.curSpeed = 0;
                     temp.character.CurDamage = temp.character.baseDamage / 2;
                 },
                 () => { temp.character.curHealthPoints -= 10; },
                 null
                );

        temp.character.BuffAdd(temp);
        CurConcentrationPoints -= skill4Usage;
    }

    public async void Initialize()
    {
       
       status = ManagerStatus.Online;
    }

    
}
