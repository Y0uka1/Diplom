using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartButton : MonoBehaviour
{
    Button button;

    public void Initialize()
    {
          button = GetComponent<Button>();
          button.onClick.AddListener(TownManager.teamBuilder.TeamReady);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
