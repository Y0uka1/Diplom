using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour, IManager
{

    static List<IManager> managers;
    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;
    public static ManagerStatus Status;
    public static BattleManager battleManager;
    public static PlayersTeam playersTeam;
    public static EnemyTeam enemyTeam;
    public static SkillExecute skillManager;
    public static UIManager ui;
    public static InventoryManager inventory;
    void Awake()
    {
       

       // playersTeam = new ICharObject[4];

      //  enemyTeam = new ICharObject[4];

        

        battleManager = GetComponent<BattleManager>();
        skillManager = GetComponent<SkillExecute>();
        playersTeam = GetComponent<PlayersTeam>();
        enemyTeam = GetComponent<EnemyTeam>();
        ui = GetComponent<UIManager>();
        inventory = GetComponent<InventoryManager>();
        managers = new List<IManager>();
        
       // managers.Add(battleManager);
        managers.Add(skillManager);
       // managers.Add(ui);
        managers.Add(playersTeam);
        managers.Add(enemyTeam);
        managers.Add(inventory);
        Initialize();

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Initialize()
    {
        foreach(var temp in managers)
        {
            temp.Initialize();
        }
        Status=ManagerStatus.Initialized;
        status = ManagerStatus.Initialized;
    }

    /*public static void InitializePlayersTeam()
    {
        foreach (var i in playersTeam)
            managers.Add(i);   
    }

    public static void InitializeEnemyTeam()
    {
        foreach (var i in enemyTeam)
            managers.Add(i);
    }*/

    public static void InitializeBattleManager()
    {
        BattleStart.Initialize();
        battleManager.Initialize();
        ui.Initialize();

        
    }
}
