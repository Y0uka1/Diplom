using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam :MonoBehaviour, IManager
{
    public ICharacterStats[] team;
    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

    public void CreateEnemyTeam()
    {
        for(int i = 0; i < team.Length; i++)
        {
            team[i] = new TestCharacter();
            team[i].charType = CharacterType.Enemy;
        }
    }

    public void Initialize()
    {
        team = new ICharacterStats[4];
        
        status = ManagerStatus.Initialized;
        Debug.Log("Enemy's team manager online");
    }
}
