using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour, IManager
{
    public TurnType currentTurn;
    //public delegate void GoBattle();
    //public event GoBattle targetRedy;
    
   // List<ICharacter> characters;
    List<ICharacterStats> currentTurnCharacters;
    public ICharacterStats currentChar;
    public delegate void Execute();
    public delegate void ExeAttack();
    public event ExeAttack ExecuteAttack;
    public Execute skill;
    //List<ICharacter> Allys;
    public ICharacterStats target;
    public delegate void TurnChanges();
    public event TurnChanges OnTurnChangesEvent;
    
    public delegate void SwitchChar();
    public event SwitchChar Switch;
    System.Random rand;
    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

    void Start()
    {
        
    }

    void ChangeTurn()
    {
        
        OnTurnChangesEvent.Invoke();
    }

    void OnTurnChanges()
    {
        if (currentTurnCharacters.Count < 1)
            RefreshCurChars();
        currentChar = FindFastAsFuck();
       // currentChar.go.transform.localScale += new Vector3(.2f, .2f, .2f);
      //  currentChar.go.GetComponent<Renderer>().material.color = Color.red;
        if (currentChar.charType == CharacterType.Ally)
        {
            currentTurn = TurnType.Player;
            Switch.Invoke();
        }
        else
        {
            currentTurn = TurnType.Enemy;
            OnEnemyAttack();
        }
    }


    ICharacterStats FindFastAsFuck ()
    {
        ICharacterStats currentChar = currentTurnCharacters[0];
        foreach (var temp in currentTurnCharacters)
        {
            if (temp.baseSpeed > currentChar.baseSpeed)
                currentChar = temp;
        }
        currentTurnCharacters.Remove(currentChar);
       // Debug.Log(currentChar.name);
        SkillExecute.character= currentChar;

        return currentChar;
    }

    public  void Initialize()
    {
        Debug.Log("Battle Manager online");
        rand = new System.Random();

        RefreshCurChars();

       
        // ExecuteEnemyAttack += OnEnemyAttack;
        status = ManagerStatus.Initialized;
        OnTurnChangesEvent += OnTurnChanges;
        ExecuteAttack += OnExecuteAttack;

        MainManager.skillManager.Initialize();

        

        ChangeTurn();
    }

    public IEnumerator BattleStart()
    {
       
        while(MainManager.Status != ManagerStatus.Initialized)
            yield return new WaitForSeconds(0.5f);
        
    }

    private void RefreshCurChars()
    {
        currentTurnCharacters = new List<ICharacterStats>();
        foreach (var i in MainManager.playersTeam.team)
        {
            currentTurnCharacters.Add(i);
        }
        foreach (var i in MainManager.enemyTeam.team)
        {
            currentTurnCharacters.Add(i);
        }
    }

    public void OnTargetReady()
    {
       
        skill();
        //currentChar.go.GetComponent<Renderer>().material.color = Color.white;
        
        ExecuteAttack.Invoke();
      
    }

    private  void OnEnemyAttack()
    {
        Debug.Log("Enemy is attacking");
        StartCoroutine(isEnemyAttack());
       
    }

    private IEnumerator isEnemyAttack()
    {
       
        target = MainManager.playersTeam.team[rand.Next(0, 4)];
        yield return new WaitForSecondsRealtime(1.5f);
        target.TakeDamage(currentChar.baseDamage);
        //currentChar.go.GetComponent<Renderer>().material.color = Color.white;
        
        ExecuteAttack.Invoke();
       
    }

    void OnExecuteAttack()
    {

        currentChar = null;
        target = null;
        skill = null;
        ChangeTurn();
    }
    
    private void Update()
    {
        
    }
}
