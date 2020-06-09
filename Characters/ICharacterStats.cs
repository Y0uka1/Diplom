using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterStats
{
    public System.Type type;
    public string typeString;
    [NonSerialized] public ICharObject link;
    public double maxHealthPoints;
    [NonSerialized] public double curHealthPoints;
    public double CurHealthPoints { get { return curHealthPoints; }
        set
        {
            /*  if((curHealthPoints-value) <= 0)
              {
                  value = curHealthPoints;
              }*/
            if (value <= 0)
            {
                curHealthPoints = 0;
                Death();
            } else if (value > maxHealthPoints)
            {
                curHealthPoints = maxHealthPoints;
            }
            else
            {
                curHealthPoints = value;
            }
        }
    }
    public double maxConcentrationPoints;
    [NonSerialized] private double curConcentrationPoints;
    public double CurConcentrationPoints { get { return curConcentrationPoints; }
        set
        {
            if (value < 0)
                curConcentrationPoints = 0;
            else if (value > maxConcentrationPoints)
                curConcentrationPoints = maxConcentrationPoints;
            else
                curConcentrationPoints = value;
        }
    }
    public double armor;
    [NonSerialized] public double curArmor;
    public double baseDamage;
    [NonSerialized] public double curDamage;
    public CharacterType charType;
    public double baseSpeed;
    [NonSerialized] public double curSpeed;
   [NonSerialized] public double maxMorale;
    public double curMorale;
    public CharClassEnum charClass;
    public int weaponLevel =0;
    public int armorLevel = 0;
    public int skill1Level = 0;
    public int skill2Level = 0;
    public int skill3Level = 0;
    public int skill4Level = 0;
    public float skill2Usage;
    public float skill3Usage;
    public float skill4Usage;
    public float concentrationRegeneration;
    public CharacterType skill1Target;
    public CharacterType skill2Target;
    public CharacterType skill3Target;
    public CharacterType skill4Target;

  

    List<ArtifactDictionary.Artifact> artifacts;


    public ICharacterStats()
    {
        artifacts = new List<ArtifactDictionary.Artifact>();
        maxMorale = 150;
        weaponLevel = 0;
        armorLevel = 0;
        skill1Level = 0;
        skill2Level = 0;
        skill3Level = 0;
        skill4Level = 0;
        
    }

    public virtual void TakeDamage(double dmg)
    {
        this.CurHealthPoints -= dmg - (armor + (2*armorLevel));
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

   

    protected void CurrentStatsInitialize()
    {
        curHealthPoints = maxHealthPoints;
       
        curConcentrationPoints = maxConcentrationPoints;
      
        curArmor = armor;
     
        curDamage = baseDamage;
   
        curSpeed = baseSpeed;
    }

   public virtual void LooseMorale(double damage)
    {
        curMorale -= damage;
        if (curMorale <= 0)
            Death();
    }

}
