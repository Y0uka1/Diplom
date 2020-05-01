using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelSelect : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LevelLoad);
    }

    private void LevelLoad()
    {
        TeamBuilder.loadLevelName = "TestLevel";
    }
}
