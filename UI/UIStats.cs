﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    Text stats;
    string statsText;
    ICharacterStats character;
    public void Initialize()
    {
        stats = GetComponent<Text>();
       // MainManager.battleManager.ExecuteAttack += OnTurnChanges;
        MainManager.battleManager.OnTurnChangesEvent += OnTurnChanges;
        OnTurnChanges();
    }

    private void OnTurnChanges()
    {
        character = MainManager.battleManager.currentChar;
        statsText = $"HP:{character.curHealthPoints}/{character.maxHealthPoints}\t Armor:{character.curArmor}/{character.armor} \n" +
            $"CP:{character.CurConcentrationPoints}/{character.maxConcentrationPoints}\nDamage:{character.curDamage}/{character.baseDamage}\nSpeed:{character.baseSpeed}" +
            $"Weapon:{character.weaponLevel}\t Armor{character.armorLevel}";
        stats.text = statsText;
    }
}
