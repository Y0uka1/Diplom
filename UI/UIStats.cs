using System.Collections;
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
    }

    private void OnTurnChanges()
    {
        character = MainManager.battleManager.currentChar;
        statsText = $"HP:{character.curHealthPoints}/{character.maxHealthPoints}\t Armor:{character.armor} \nCP:{character.maxConcentrationPoints}\nDamage:{character.baseDamage}\nSpeed:{character.baseSpeed}";
        stats.text = statsText;
    }
}
