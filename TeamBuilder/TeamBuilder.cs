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

        //  foreach(var i in MainManager.navigationMaster.detailsList)
        // {
        //     i.SetActive(true);
        // }
        foreach (var i in MainManager.playersTeam.team)
        {
            if (i != null)
            {
               SceneManager.LoadScene(loadLevelName);
                break;
            }
        }
        
    }

    public void Initialize()
    {
        team = new ICharacterStats[4];
        placeholders = new Placeholder[4];
       placeholders = FindObjectsOfType<Placeholder>();
       
    }
}
