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
            hBar.transform.localScale = new Vector2(5.5f, hBar.transform.localScale.y);
            hBarValue = hBar.GetComponentInChildren<HealthBarValue>();
            MainManager.battleManager.OnTurnChangesEvent += ValueRefresh;
        
        
    }
    public void ValueRefresh()
    {
        if (character == null || character.CurHealthPoints <= 0)
        {
            Destroy(hBar);
        }
        else
        {
            float temp = (float)character.curHealthPoints / (float)character.maxHealthPoints;
            hBarValue.ValueChange(Mathf.Clamp(temp, 0, 1));
        }
    }

    public void SetPosition()
    {
        if (hBar != null && character != null)
            hBar.transform.position = new Vector3(character.link.transform.position.x, character.link.transform.position.y + 4, character.link.transform.position.z);
        else
            Destroy(hBar);
    }
}
