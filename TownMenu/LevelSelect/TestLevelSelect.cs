using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelSelect : MonoBehaviour
{
    Button button;
    public int Level;

    public void Initialize()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(this.LevelLoad);
    }

   

    public void LevelLoad()
    {
        TownManager.teamBuilder.loadLevelName = "TestLevel";
        LootManager.level = Level;
    }
}
