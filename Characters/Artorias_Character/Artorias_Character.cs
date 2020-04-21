using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artorias_Character : ICharacterStats
{

    public System.Type type { get; set; } = typeof(ArtoriasCharGObject);
    public ICharObject link { get; set; }
    public double healthPoints { get ; set; }
    public double curHealthPoints { get; set; }
    public double concentrationPoints { get; set; }
    public double armor { get; set; }
    public double baseDamage { get; set; }
    public CharacterType charType { get; set; }
    public double baseSpeed { get; set; }


    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;
    public GameObject gObject { get; set; }

    public bool skillSelected;

   

    public Artorias_Character()
    {
        healthPoints = 100;
        curHealthPoints = healthPoints;
        concentrationPoints = 100;
        armor = 10;
        baseDamage = 15;
        baseSpeed = 13;
    }

    public  void Death()
    {
        Debug.Log("OMG I'm Dead");
    }

    public  void Skill_1()
    {

        Debug.Log("Artorias Skill 1 Executed");
        MainManager.battleManager.target.TakeDamage(16);

    }

    public  void Skill_2()
    {
        Debug.Log("Artorias Skill 2 Executed");
        MainManager.battleManager.target.TakeDamage(15);
    }

    public  void Skill_3()
    {
        Debug.Log("Artorias Skill 3 Executed");
        MainManager.battleManager.target.TakeDamage(14);
    }

    public  void Skill_4()
    {
        Debug.Log("Artorias Skill 4 Executed");
        MainManager.battleManager.target.TakeDamage(13);
    }

    public  void TakeDamage(double dmg)
    {
        this.curHealthPoints -= dmg - armor;   
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public async void Initialize()
    {
       
       status = ManagerStatus.Initialized;
    }
}
