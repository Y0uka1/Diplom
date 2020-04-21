using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStats
{
     System.Type type { get; set; }
     ICharObject link { get; set; }
     double healthPoints { get; set; }
     double curHealthPoints { get; set; }
     double concentrationPoints { get; set; }
     double armor { get; set; }
     double baseDamage { get; set; }
     CharacterType charType { get; set; }
     double baseSpeed { get; set; }
     void TakeDamage(double dmg);
     void Death();
     void Skill_1();
     void Skill_2();
     void Skill_3();
     void Skill_4();

    //void OnClicked();

}
