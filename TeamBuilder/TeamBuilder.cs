using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamBuilder : ScriptableObject, IManager
{
   // public static ICharacterStats tempCharacter { get; set; }
    public  ICharacterStats[] team;
    public  Placeholder[] placeholders;
    public  Placeholder activePlaceholder;
    public delegate void ActivePlaceHolder();
    public  event ActivePlaceHolder Activate;
    // public static List<GameObject> characterList;
    //Button button;
    public  string loadLevelName;

    public ManagerStatus status { get; set ; }

    private void Start()
    {
        Initialize();
        // characterList = new List<GameObject>();
      //  button = GetComponent<Button>();
      //  button.onClick.AddListener(TeamReady);
        
    }

    public void PlaceholderActivate()
    {
        Activate.Invoke();
    }

    public void TeamReady()
    {
        //placeholders = FindObjectsOfType<Placeholder>();

        foreach (var i in placeholders)
        {
            team[i.index] = i.character;
        }

        MainManager.playersTeam.team = team;

        SceneManager.LoadScene(loadLevelName);
    }

    public void Initialize()
    {
        team = new ICharacterStats[4];
        placeholders = new Placeholder[4];
    }
}
