using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour, IManager
{

    static List<IManager> managers;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    public static ManagerStatus Status;
    public static BattleManager battleManager;
    public static PlayersTeam playersTeam;
    public static EnemyTeam enemyTeam;
    public static SkillExecute skillManager;
    public static UIManager ui;
    public static InventoryManager inventory;
    public static NavigationMaster navigationMaster;
    //  public static TeamBuilder teamBuilder;
    public static CharactersSave charSave;
    public static ResourcesData resourcesData;
    public static List<ICharacterStats> busyChars;
    public static RequestStruct requestedResources;
    void Awake()
    {


        // playersTeam = new ICharObject[4];

        //  enemyTeam = new ICharObject[4];

        SceneManager.sceneLoaded += TownManagerInitialize;

        busyChars = new List<ICharacterStats>();

        battleManager = GetComponent<BattleManager>();
        skillManager = GetComponent<SkillExecute>();
        playersTeam = GetComponent<PlayersTeam>();
        enemyTeam = GetComponent<EnemyTeam>();
        ui = GetComponent<UIManager>();
        inventory = GetComponent<InventoryManager>();
       // teamBuilder = ScriptableObject.CreateInstance(typeof(TeamBuilder)) as TeamBuilder;
        managers = new List<IManager>();
        
       // managers.Add(battleManager);
        managers.Add(skillManager);
       // managers.Add(ui);
        managers.Add(playersTeam);
        managers.Add(enemyTeam);
        managers.Add(inventory);
       // managers.Add(teamBuilder);
        Initialize();

        DontDestroyOnLoad(this);
    }

 

    public void Initialize()
    {
        charSave = ScriptableObject.CreateInstance(typeof(CharactersSave)) as CharactersSave;
        charSave.Initialize();
        charSave.LoadData();

        
        ResourcesData.LoadData();
        requestedResources = new RequestStruct();
        requestedResources.LoadData();

        foreach (var temp in managers)
        {
            temp.Initialize();
        }

        Status =ManagerStatus.Online;
        status = ManagerStatus.Online;

        
    }

    public void TownManagerInitialize(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Town")
        {

            navigationMaster = GameObject.FindObjectOfType<NavigationMaster>();
            navigationMaster.Initialize();
        }
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
