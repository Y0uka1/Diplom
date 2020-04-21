using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayersTeam : MonoBehaviour, IManager
{
   // [SerializeField]
    public ICharacterStats[] team;

    public  ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

   

    public  void Initialize()
    {
        team = new ICharacterStats[4];
        status = ManagerStatus.Initialized;
        Debug.Log("Player's team manager online");
    }

    
}
