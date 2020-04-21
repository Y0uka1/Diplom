using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField]
    public int skillnumber;
    public Button button;
    public BattleManager.Execute exe;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSkillClicked);
    }

    private void Start()
    {
        MainManager.battleManager.Switch += SwitchSkill;
    }
    private void OnSkillClicked()
    {
        SwitchSkill();

        MainManager.battleManager.skill = exe;
    }

    public void SwitchSkill()
    {
        switch (skillnumber)
        {
            case 1:
                {
                    exe = MainManager.battleManager.currentChar.Skill_1;
                    break;
                }
            case 2:
                {
                    exe = MainManager.battleManager.currentChar.Skill_2;
                    break;
                }
            case 3:
                {
                    exe = MainManager.battleManager.currentChar.Skill_3;
                    break;
                }
            case 4:
                {
                    exe = MainManager.battleManager.currentChar.Skill_4;
                    break;
                }
        }
    }
}
