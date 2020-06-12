using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBCharStats : MonoBehaviour
{
    Text text;
    public void Initialize()
    {
        text = GetComponent<Text>();
        text.text = "";
    }

    public void Refresh(ICharacterStats stats)
    {
        text.text = $"Здоровье: {stats.maxHealthPoints}\t Концентрация: {stats.maxHealthPoints}\n Восстановление концентрации: {stats.concentrationRegeneration}\n Броня: {stats.armor}\t " +
            $"Урон: {stats.baseDamage}\n Скорость: {stats.baseSpeed}\t Мотивация: {stats.curMorale}\n " +
            $"Уровень оружия: {stats.weaponLevel}\t Уровень доспехов: {stats.armorLevel}\n {stats.skill1Name}: {stats.skill1Level}\t {stats.skill2Name}: {stats.skill2Level}\n" +
            $"{stats.skill3Name}: {stats.skill3Level}\t {stats.skill4Name}: {stats.skill4Level}";
    }
}
