using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayersTeam : MonoBehaviour, IManager
{
   // [SerializeField]
    public ICharacterStats[] team;
    public TorchBar torchBar;
    public bool isInBattle = false;
    public  ManagerStatus status { get; set; } = ManagerStatus.Offline;

    private int torchLight = 100;
    public int TorchLight {
        get { return torchLight; } 
        set {
            if (value > 100)
            {
               torchLight = 100;
            }else if(value < 0)
            {
                torchLight = 0;
            }
            else
            {
                torchLight = value;
            }
            torchBar.ValueChange((float)torchLight/100);

        }
    }

    public  void Initialize()
    {
        torchLight = 100;

        team = new ICharacterStats[4];
        status = ManagerStatus.Online;
       
        Debug.Log("Player's team manager online");
    }

    
}
