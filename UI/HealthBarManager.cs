using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour , IManager
{
    public HealthBarGO[] hBarList;
    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

  /*  public void Initialize(ICharacterStats character)
    {
        this.character = character;
        hBar = Resources.Load<GameObject>("Prefabs/HealthBar");
        Instantiate(hBar);

        Debug.Log(hBar.transform.position);
    }
    */
    public void Initialize()
    {
        hBarList = new HealthBarGO[8];
        for(int i = 0; i < 4; i++)
        {
            hBarList[i] = Instantiate(new GameObject().AddComponent<HealthBarGO>());
            hBarList[i].Initialize();

            hBarList[i].character = MainManager.playersTeam.team[i];
            hBarList[i].SetPosition();
           
        }
        for (int i = 0; i < 4; i++)
        {
            hBarList[i+4] = Instantiate(new GameObject().AddComponent<HealthBarGO>());
            hBarList[i+4].Initialize();
            hBarList[i+4].character = MainManager.enemyTeam.team[i];
           
            hBarList[i+4].SetPosition();
        }
        status = ManagerStatus.Initialized;
    }

   
    private void Update()
    {
       /* float curH = (float)character.healthPoints / ((float)character.curHealthPoints * 100);
        transform.localScale= new Vector3(curH, transform.localScale.y, transform.localScale.z);
        */
    }

}
