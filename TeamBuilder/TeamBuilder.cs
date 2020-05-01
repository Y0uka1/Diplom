using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamBuilder : MonoBehaviour
{
   // public static ICharacterStats tempCharacter { get; set; }
    public static ICharacterStats[] team;
    public static Placeholder[] placeholders;
    public static Placeholder activePlaceholder;
    public delegate void ActivePlaceHolder();
    public static event ActivePlaceHolder Activate;
    // public static List<GameObject> characterList;
    Button button;
    public static string loadLevelName;

    private void Start()
    {
        team = new ICharacterStats[4];
        placeholders = new Placeholder[4];
        // characterList = new List<GameObject>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TeamReady);
        
    }

    public static void PlaceholderActivate()
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

    
}
