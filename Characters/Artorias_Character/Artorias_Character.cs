using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Artorias_Character : ICharacterStats
{
    public bool skillSelected;
    ManagerStatus status = ManagerStatus.Shutdown;
    

    public Artorias_Character():base()
    {
        charClass = CharClassEnum.Artorias;
        type = typeof(ArtoriasCharGObject);
        typeString = type.ToString();
        maxHealthPoints = 100;
        curHealthPoints = maxHealthPoints;
        maxConcentrationPoints = 100;
        curConcentrationPoints = maxConcentrationPoints;
        armor = 10;
        curArmor = armor;
        baseDamage = 15;
        baseSpeed = 13;
        curSpeed = baseSpeed;
        skill2Usage = 10;
        skill3Usage = 15;
        skill4Usage = 20;
        concentrationRegeneration = 5;
    }

    

    public override void Skill_1()
    {

        Debug.Log("Artorias Skill 1 Executed");
        MainManager.battleManager.target.TakeDamage(16);

    }

    public override void Skill_2()
    {
        Debug.Log("Artorias Skill 2 Executed");
        MainManager.battleManager.target.TakeDamage(15);
    }

    public override void Skill_3()
    {
        Debug.Log("Artorias Skill 3 Executed");
        MainManager.battleManager.target.TakeDamage(14);
    }

    public override void Skill_4()
    {
        Debug.Log("Artorias Skill 4 Executed");
        MainManager.battleManager.target.TakeDamage(13);
    }

    public async void Initialize()
    {
       
       status = ManagerStatus.Initialized;
    }

    
}
