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
    public float usage;
    
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
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill1Target;
                    usage = 0;
                    break;
                }
            case 2:
                {
                    exe = MainManager.battleManager.currentChar.Skill_2;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill2Target;
                    usage = MainManager.battleManager.currentChar.skill2Usage;
                    break;
                }
            case 3:
                {
                    exe = MainManager.battleManager.currentChar.Skill_3;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill3Target;
                    usage = MainManager.battleManager.currentChar.skill3Usage;
                    break;
                }
            case 4:
                {
                    exe = MainManager.battleManager.currentChar.Skill_4;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill4Target;
                    usage = MainManager.battleManager.currentChar.skill4Usage;
                    break;
                }
        }
        if (usage > MainManager.battleManager.currentChar.CurConcentrationPoints)
            button.interactable = false;
        else
            button.interactable = true;
    }
}
