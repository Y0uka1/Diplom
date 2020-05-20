using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempBut : MonoBehaviour
{
    Button button;
    CharactersSave charSave;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        charSave = ScriptableObject.CreateInstance(typeof(CharactersSave)) as CharactersSave;
    }


    void OnClick()
    {
        charSave.SaveData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
