using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleFeed : MonoBehaviour
{
    Text feed;
    string feedText;
    public void Initialize()
    {
        feed = GetComponent<Text>();
        // MainManager.battleManager.ExecuteAttack += OnTurnChanges;
        MainManager.battleManager.ExecuteAttack += OnAttack;
    }

    private void OnAttack()
    {
       
    //    feedText = $"{MainManager.battleManager.currentChar.go.name} is attacking {MainManager.battleManager.target}";
        feed.text = feedText;
    }
}
