using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResMainManager : MonoBehaviour
{
    
    [SerializeField] public static List<ICharacterStats> availableCharacters;


    public static void RemoveCharacter(ICharacterStats chara)
    {
        availableCharacters.Remove(chara);
    }

    public static void AddCharacter(ICharacterStats chara)
    {
        availableCharacters.Add(chara);
    }

}
