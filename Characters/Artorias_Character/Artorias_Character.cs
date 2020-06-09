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
        skill2Usage = 10;
        skill3Usage = 15;
        skill4Usage = 20;
        concentrationRegeneration = 5;

        skill1Target = CharacterType.Enemy;
        skill2Target = CharacterType.Ally;
        skill3Target = CharacterType.Enemy;
        skill4Target = CharacterType.Enemy;

        base.CurrentStatsInitialize();
    }

    

    public override void Skill_1()
    {
        MainManager.battleManager.target.TakeDamage(25);
    }

    public override void Skill_2()
    {
        MainManager.battleManager.BuffAdd(
           new BuffStruct(
               2,
                this,
                () => { this.curDamage += 15; },
                null,
                () => { this.curDamage -= 15; }
               )
           );
        CurConcentrationPoints -= skill2Usage;
    }

    public override void Skill_3()
    {
        BuffStruct temp = new BuffStruct(); 
        temp = new BuffStruct(
                4,
                 temp.character = MainManager.battleManager.target,
                 () => { temp.character.curDamage -= 8; },
                 null,
                 () => { temp.character.curDamage += 8; }
                );

        MainManager.battleManager.BuffAdd(temp);
        MainManager.battleManager.target.TakeDamage(15);
        CurConcentrationPoints -= skill3Usage;
    }

    public override void Skill_4()
    {
        BuffStruct temp = new BuffStruct(); 
        temp = new BuffStruct(
                3,
                 temp.character = MainManager.battleManager.target,
                 () => { temp.character.curArmor -= 5; },
                 () => { temp.character.curHealthPoints -= 10; },
                 () => { temp.character.curArmor += 5; }
                );

        MainManager.battleManager.BuffAdd(temp);

        Debug.Log("Artorias Skill 4 Executed");
        MainManager.battleManager.target.TakeDamage(1);
        CurConcentrationPoints -= skill4Usage;
    }

    public async void Initialize()
    {
       
       status = ManagerStatus.Online;
    }

    
}
