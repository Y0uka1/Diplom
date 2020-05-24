using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : ScriptableObject
{
    LevelStartButton startButton;
    TestLevelSelect select;

    public void Initialize()
    {
        startButton = FindObjectOfType<LevelStartButton>();
        startButton.Initialize();
        select = FindObjectOfType<TestLevelSelect>();
        select.Initialize();
    }
}
