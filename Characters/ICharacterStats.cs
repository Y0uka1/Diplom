using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterStats
{
    public int id;
    public System.Type type;
    public string typeString;
    [NonSerialized] public ICharObject link;
    public double maxHealthPoints;
    [NonSerialized] public double curHealthPoints;
    [NonSerialized] public string avatarPath;
    public double CurHealthPoints { get { return curHealthPoints; }
        set
        {
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
    [NonSerialized] double curDamage;
    public double CurDamage
    {
        get { return curDamage; }
        set
        {
            if (value < 0)
                curDamage = 0;
            else
                curDamage = value;
        }
    }
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

    public string skill1Name;
    public string skill2Name;
    public string skill3Name;
    public string skill4Name;

    List<ArtifactDictionary.Artifact> artifacts;

    [NonSerialized] List<BuffStruct> buffs;

    public ICharacterStats(int id)
    {
        artifacts = new List<ArtifactDictionary.Artifact>();
        maxMorale = 150;
        weaponLevel = 0;
        armorLevel = 0;
        skill1Level = 0;
        skill2Level = 0;
        skill3Level = 0;
        skill4Level = 0;
        this.id = id;
        buffs = new List<BuffStruct>();
    }

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
        buffs = new List<BuffStruct>();

    }

    public virtual void TakeDamage(double dmg)
    {
        double total = dmg - (armor + (2 * armorLevel));
        if (total < 0)
            total = 0;
        this.CurHealthPoints -=total;
    }
    public virtual void Death () {
        Debug.Log("DEad" + id);      
        for (int i = 0; i < MainManager.battleManager.currentTurnCharacters.Count; i++)
        {
            if (MainManager.battleManager.currentTurnCharacters[i].id == this.id)
            {
                MainManager.battleManager.currentTurnCharacters.Remove(MainManager.battleManager.currentTurnCharacters[i]);
                break;
            }
        }


        if (this.charType == CharacterType.Ally)
        {
            for (int i = 0; i < MainManager.playersTeam.team.Length; i++)
            {
                if (MainManager.playersTeam.team[i] != null)
                {
                    if (MainManager.playersTeam.team[i].id == this.id)
                    {
                        MainManager.playersTeam.team[i] = null;
                        break;
                    }
                }


            }
        }
        else
        {
            for (int i = 0; i < MainManager.enemyTeam.team.Length; i++)
            {
                if (MainManager.enemyTeam.team[i] != null)
                {
                    if (MainManager.enemyTeam.team[i].id == this.id)
                    {
                        MainManager.enemyTeam.team[i] = null;
                        break;
                    }
                }
            }
        }
            for (int i = 0; i < MainManager.charSave.characters.Count; i++)
            {
                 if (MainManager.charSave.characters[i].id == this.id)
                 {
                    CharactersSave.RemoveChar(MainManager.charSave.characters[i]);
                    break;
                 }
            }
        link.Death();
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
     //   if (curMorale <= 0)
       //     Death();
    }

    public virtual void BuffAdd(BuffStruct buff)
    {
        buffs.Add(buff);
        buff.OnBuffAdd?.Invoke();
    }

    public virtual void BuffRemove(BuffStruct buff)
    {
        buffs.Remove(buff);
    }

    public virtual void OnTurnPassed()
    {
       for(int i = 0; i < buffs.Count; i++)
        {
            buffs[i].TurnPassed();
        }
        CurConcentrationPoints += concentrationRegeneration;
    }

}
