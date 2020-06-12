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
    bool active;
    Text desc;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSkillClicked);
        desc = GameObject.Find("SkillDesc").GetComponentInChildren<Text>();
    }

    private void Start()
    {
        active = false;
        MainManager.battleManager.Switch += SwitchSkill;
    }
    private void OnSkillClicked()
    {
        SwitchSkill();

        Image img = gameObject.GetComponent<Image>();
        if (active == false)
        {
            img.color = new Color(img.color.r, img.color.g + 40, img.color.b);
        }
        else
        {
            img.color = new Color(img.color.r, img.color.g - 40, img.color.b);
        }
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
                    desc.text = SkillDescriptions.GetDescriptions(MainManager.battleManager.currentChar.charClass)[0];
                    break;
                }
            case 2:
                {
                    exe = MainManager.battleManager.currentChar.Skill_2;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill2Target;
                    usage = MainManager.battleManager.currentChar.skill2Usage;
                    desc.text = SkillDescriptions.GetDescriptions(MainManager.battleManager.currentChar.charClass)[1];
                    break;
                }
            case 3:
                {
                    exe = MainManager.battleManager.currentChar.Skill_3;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill3Target;
                    usage = MainManager.battleManager.currentChar.skill3Usage;
                    desc.text = SkillDescriptions.GetDescriptions(MainManager.battleManager.currentChar.charClass)[2];
                    break;
                }
            case 4:
                {
                    exe = MainManager.battleManager.currentChar.Skill_4;
                    MainManager.battleManager.targetType = MainManager.battleManager.currentChar.skill4Target;
                    usage = MainManager.battleManager.currentChar.skill4Usage;
                    desc.text = SkillDescriptions.GetDescriptions(MainManager.battleManager.currentChar.charClass)[3];
                    break;
                }
        }
        if (usage > MainManager.battleManager.currentChar.CurConcentrationPoints)
            button.interactable = false;
        else
            button.interactable = true;
    }
}
