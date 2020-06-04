using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillExecute : MonoBehaviour, IManager
{
    public static ICharacterStats character;

    SkillUI[] skills;
   
    [SerializeField]
    int skillNumber;

    public ManagerStatus status { get; set; } = ManagerStatus.Offline;


    public void Refresh()
    {
        
    }

    

    public void Initialize()
    {
        MainManager.battleManager.Switch += Refresh;
        Debug.Log("Skill manager online");
    }
}
