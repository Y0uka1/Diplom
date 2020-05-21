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
    public double morale = 150;
    public CharClassEnum charClass;
    public int weaponLevel =0;
    public int armorLevel = 0;
    public int skill1Level = 0;
    public int skill2Level = 0;
    public int skill3Level = 0;
    public int skill4Level = 0;
    public float skill1Usage =0;
    public float skill2Usage;
    public float skill3Usage;
    public float skill4Usage;
    public float concentrationRegeneration;

    List<ArtifactDictionary.Artifact> artifacts;


    public ICharacterStats()
    {
        artifacts = new List<ArtifactDictionary.Artifact>();
        morale = 150;
        weaponLevel = 0;
        armorLevel = 0;
        skill1Level = 0;
        skill2Level = 0;
        skill3Level = 0;
        skill4Level = 0;
        skill1Usage = 0;
    }

    public virtual void TakeDamage(double dmg)
    {
        this.curHealthPoints -= dmg - (armor + (2*armorLevel));
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

    public virtual void ArtifactAdd(ArtifactDictionary.Artifact artifact)
    {
        artifacts.Add(artifact);
    }

    public virtual void ArtifactRemove(ArtifactDictionary.Artifact artifact)
    {
        artifacts.Remove(artifact);
    }
    //void OnClicked();

}
