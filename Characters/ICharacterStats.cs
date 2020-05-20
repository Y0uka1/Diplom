using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStats
{
     System.Type type { get; set; }
     ICharObject link { get; set; }
     double maxHealthPoints { get; set; }
     double curHealthPoints { get; set; }
     double maxConcentrationPoints { get; set; }
     double curConcentrationPoints { get; set; }
     double armor { get; set; }
     double curArmor { get; set; }
     double baseDamage { get; set; }
     double curDamage { get; set; }
     CharacterType charType { get; set; }
     double baseSpeed { get; set; }
     double curSpeed { get; set; }
     double morale { get; set; }
     void TakeDamage(double dmg);
     void Death();
     void Skill_1();
     void Skill_2();
     void Skill_3();
     void Skill_4();

     string SaveToString();
    //void OnClicked();

}
