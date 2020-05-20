using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterStats
{
    public System.Type type;
    public string typeString;
    public ICharObject link;
    public double maxHealthPoints;
    public double curHealthPoints;
    public double maxConcentrationPoints;
    public double curConcentrationPoints;
    public double armor;
    public double curArmor;
    public double baseDamage;
    public double curDamage;
    public CharacterType charType;
    public double baseSpeed;
    public double curSpeed;
    public double morale;
    public CharClassEnum charClass;
    public virtual void TakeDamage(double dmg)
    {
        this.curHealthPoints -= dmg - armor;
    }
    public virtual void Death () {
        Debug.Log("OMG I'm Dead");
    }
    public virtual void Skill_1() { }
    public virtual void Skill_2() { }
    public virtual void Skill_3() { }
    public virtual void Skill_4() { }

    public virtual string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    //void OnClicked();

}
