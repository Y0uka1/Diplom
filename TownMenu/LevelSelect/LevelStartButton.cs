using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartButton : MonoBehaviour
{
    Button button;

    void Start()
    {
          button = GetComponent<Button>();
          button.onClick.AddListener(MainManager.teamBuilder.TeamReady);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
