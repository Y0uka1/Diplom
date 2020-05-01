using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarGO:MonoBehaviour
{
    public GameObject hBar;
    public ICharacterStats character;
    public HealthBarValue hBarValue;

   
    public void Initialize()
    {

            hBar = Instantiate(Resources.Load<GameObject>("Prefabs/HealthBar"));
            hBar.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerTeam").transform);
            hBarValue = hBar.GetComponentInChildren<HealthBarValue>();
            MainManager.battleManager.OnTurnChangesEvent += ValueRefresh;
        
    }
    public void ValueRefresh()
    {
        float temp = (float)character.curHealthPoints / (float)character.maxHealthPoints ;
        hBarValue.ValueChange(Mathf.Clamp(temp,0,1));
    }

    public void SetPosition()
    {
        
        hBar.transform.position = new Vector3(character.link.transform.position.x - 1.5f, character.link.transform.position.y + 4, character.link.transform.position.z);
    }
}
