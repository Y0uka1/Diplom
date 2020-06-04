using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam :MonoBehaviour, IManager
{
    public ICharacterStats[] team;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;

    public System.Type[] CaveETypes;

    public void GetCaveEnemy()
    {
        CaveETypes = new System.Type[2]
        {
            typeof(EnemyTest1),
            typeof(EnemyTest2)
        };
        System.Random rand = new System.Random();

        for(int i=0;i<4;i++)
        {
            team[i] = System.Activator.CreateInstance(CaveETypes[rand.Next(0,2)]) as ICharacterStats;
        }
    }


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
        
        status = ManagerStatus.Online;
        Debug.Log("Enemy's team manager online");
    }
}
