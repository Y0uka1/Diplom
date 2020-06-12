using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour, IManager
{
    public TurnType currentTurn;
    //public delegate void GoBattle();
    //public event GoBattle targetRedy;

    // List<ICharacter> characters;
    public List<ICharacterStats> currentTurnCharacters;
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

    public CharacterType targetType;
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;


    bool win ;
    bool loose ;

    void ChangeTurn()
    {
        
        OnTurnChangesEvent.Invoke();
    }

    void OnTurnChanges()
    {
        if (MainManager.playersTeam.isInBattle)
        {

            win = true;
            loose = true;

            foreach (var i in MainManager.playersTeam.team)
            {
                if (i != null)
                {
                    loose = false;
                    break;
                }
            }

            foreach (var i in MainManager.enemyTeam.team)
            {
                if (i != null)
                {
                    win = false;
                    break;
                }
            }

            if (win == true)
            {
                OnBattleWin();
            }
            else if (loose == true)
            {
                OnBattleLost();
            }
            else
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
                currentChar.OnTurnPassed();
            }
        }
    }


     ICharacterStats FindFastAsFuck ()
    {
        ICharacterStats currentChar = currentTurnCharacters[0];
        foreach (var temp in currentTurnCharacters)
        {
            if (temp != null)
            {
                if (temp.curSpeed > currentChar.curSpeed)
                    currentChar = temp;
            }
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

     //   RefreshCurChars();

       
        // ExecuteEnemyAttack += OnEnemyAttack;

        OnTurnChangesEvent += OnTurnChanges;
        ExecuteAttack += OnExecuteAttack;
        status = ManagerStatus.Online;

      /*  MainManager.skillManager.Initialize();

        win = true;
        loose = true;

        ChangeTurn();
        MainManager.ui.InitializeBattleUI();
        MainManager.ui.healthBar.InitializeEnemyHBar();*/
    }

   /* public IEnumerator BattleStart()
    {
       
        while(MainManager.Status != ManagerStatus.Online)
            yield return new WaitForSeconds(0.5f);
        
    }*/

    private void RefreshCurChars()
    {
        currentTurnCharacters = new List<ICharacterStats>();
        foreach (var i in MainManager.playersTeam.team)
        {
            if(i!=null)
                currentTurnCharacters.Add(i);
        }
        foreach (var i in MainManager.enemyTeam.team)
        {
            if (i != null)
                currentTurnCharacters.Add(i);
        }
    }

    public void OnTargetReady()
    {
       
        skill();
        
        ExecuteAttack.Invoke();
      
    }

    private  void OnEnemyAttack()
    {
        Debug.Log("Enemy is attacking");
        StartCoroutine(isEnemyAttack());
       
    }

    private IEnumerator isEnemyAttack()
    {
        int index = rand.Next(0, 4);
        
        do
        {
            index--;
            if (index < 0)
                index = 3;
            yield return null;
        } while (MainManager.playersTeam.team[index] == null);
        target = MainManager.playersTeam.team[index];
        yield return new WaitForSecondsRealtime(1.5f);
        int randSkill = Random.Range(0,100);
        if (randSkill < 50)
        {
            currentChar.Skill_1();
        }else if (randSkill < 70)
        {
            currentChar.Skill_2();
        }else if(randSkill < 90)
        {
            currentChar.Skill_3();
        }
        else
        {
            currentChar.Skill_4();
        }

        ExecuteAttack.Invoke();
       
    }

    void OnExecuteAttack()
    {

        currentChar = null;
        target = null;
        skill = null;
        ChangeTurn();
    }

    public void OnBattleStars()
    {
        FindObjectOfType<MoveLeft>().collider.enabled = false;
        FindObjectOfType<MoveRight>().collider.enabled = false;
        MainManager.playersTeam.isInBattle = true;
        MainManager.enemyTeam.GetCaveEnemy();
        float x = GameObject.FindGameObjectWithTag("MainCamera").transform.position.x;
        
        x += 3f;
        foreach (var i in MainManager.enemyTeam.team)
        {
            GameObject temp = new GameObject();
            Vector3 pos = new Vector3(x, 1, 0);
            temp.transform.position = pos;
            System.Type type = i.type;
            var chara = temp.AddComponent(type) as ICharObject;

            chara.Initialize(i);
            x += 3f;
        }
        RefreshCurChars();
        MainManager.skillManager.Initialize();

        win = true;
        loose = true;

        ChangeTurn();
        MainManager.ui.InitializeBattleUI();
        MainManager.ui.healthBar.InitializeEnemyHBar();
    }

   

   void OnBattleLost()
    {
        currentChar = null;
        target = null;
        skill = null;

        ResourcesData.SaveData();
        MainManager.charSave.SaveData();
        MainManager.LoadLevel("Town");

        
    }

    void OnBattleWin()
    {
        currentChar = null;
        target = null;
        skill = null;

        FindObjectOfType<MoveLeft>().collider.enabled = true;
        FindObjectOfType<MoveRight>().collider.enabled = true;

        MainManager.playersTeam.isInBattle = false;

        MainManager.ui.InitializeCommonUI();
        LootManager.BattleLoot();
        MainManager.inventory.OnLootAdded();
    }

    
}
