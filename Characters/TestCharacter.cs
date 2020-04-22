using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharacter :  ICharacterStats
{
    public System.Type type { get; set; } = typeof(TestCharGObject);
    public ICharObject link { get; set; }
    public double maxHealthPoints { get; set; } = 10;
    public double curHealthPoints { get; set; }
    public double maxConcentrationPoints { get; set; } = 10;
    public double armor { get; set; } = 0.5f;
    public double baseDamage { get; set; } = 2;
    public double baseSpeed { get; set; } = 2;
    public GameObject gObject { get; set; }
    public CharacterType charType { get; set; } = CharacterType.Enemy;
    

    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;
    public double curConcentrationPoints { get ; set; }
    public double curArmor { get; set; }
    public double curDamage { get ; set ; }
    public double curSpeed { get ; set ; }
    public double morale { get ; set ; }

    public bool skillSelected;

    

    public TestCharacter()
    {
        maxHealthPoints = 10;
        curHealthPoints = maxHealthPoints;
        maxConcentrationPoints = 50;
        armor = 11;
        baseDamage = 16;
        baseSpeed = 1;
    }
    public double DealDamage()
    {
        return 0;
    }

    public void Death()
    {
       
    }

    public void Skill_1()
    {
        Debug.Log("Skill 1 Exe");
        
    }

    public void Skill_2()
    {
        Debug.Log("Skill 2 Exe");
        
    }

    public void Skill_3()
    {
        Debug.Log("Skill 3 Exe");
        
    }

    public void Skill_4()
    {
        Debug.Log("Skill 4 Exe");
        
    }

    public void TakeDamage(double dmg)
    {
        curHealthPoints -= dmg - armor;        
    }

    void Awake()
    {

        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public async void  Initialize()
    {
        //gObject = GetComponent<GameObject>();
        //if (this.gameObject.transform.position.x < 0)
           // charType = CharacterType.Ally;
      //  else
        //    charType = CharacterType.Enemy;
       // type = charType.ToString();
        status = ManagerStatus.Initialized;
    }
}
