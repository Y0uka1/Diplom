using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayersTeam : MonoBehaviour, IManager
{
   // [SerializeField]
    public ICharacterStats[] team;

    public  ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

    public int TorchLight { 
        get { return TorchLight; } 
        set {
            if (value > 100)
            {
                TorchLight = 100;
            }else if(value < 0)
            {
                TorchLight = 0;
            }
            else
            {
                TorchLight = value;
            }
        }
    }

    public  void Initialize()
    {
        team = new ICharacterStats[4];
        status = ManagerStatus.Initialized;
        Debug.Log("Player's team manager online");
    }

    
}
