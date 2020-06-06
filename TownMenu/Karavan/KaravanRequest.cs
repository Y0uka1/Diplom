using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaravanRequest : MonoBehaviour
{
    Slider moneySlider;
    Slider humanSlider;
    Slider buildSlider;

    int tempGlory;
    int moneyVal;
    int humanVal;
    int buildVal;

    Text money;
    Text human;
    Text build;
    Text glory;

    public void Initialize()
    {
        moneySlider = GameObject.Find("MoneySlider").GetComponent<Slider>();
        humanSlider = GameObject.Find("HumanSlider").GetComponent<Slider>();
        buildSlider = GameObject.Find("BuildSlider").GetComponent<Slider>();

        tempGlory = ResourcesManager.glory;

        moneySlider.maxValue = ResourcesManager.glory;
        moneySlider.wholeNumbers = true;
        moneyVal = (int)moneySlider.value;
        moneySlider.onValueChanged.AddListener(delegate { OnMoneySliderValueChange(); });
        humanSlider.maxValue = ResourcesManager.glory;
        humanSlider.wholeNumbers = true;
        humanVal = (int)humanSlider.value;
        humanSlider.onValueChanged.AddListener(delegate { OnHumanSliderValueChange(); });
        buildSlider.maxValue = ResourcesManager.glory;
        buildSlider.wholeNumbers = true;
        buildVal = (int)buildSlider.value;
        buildSlider.onValueChanged.AddListener(delegate { OnBuildSliderValueChange(); });

        glory = GameObject.Find("GloryImg").transform.GetChild(0).gameObject.GetComponent<Text>();
        UpdateValue();

        money = moneySlider.GetComponentInChildren<Text>();
        human = humanSlider.GetComponentInChildren<Text>();
        build = buildSlider.GetComponentInChildren<Text>();

        money.text = "0";
        human.text = "0";
        build.text = "0";
    }

    private void UpdateValue()
    {
        glory.text = $"{tempGlory.ToString()}/{ResourcesManager.glory.ToString()}";
    }

    public void OnMoneySliderValueChange()
    {
        int delta = (int)moneySlider.value - moneyVal;
        if (tempGlory - delta >= 0)
        {
            tempGlory -= delta;
        }
        else
        {
            int negative = tempGlory - delta;
            moneySlider.value += negative;
            tempGlory = 0;
        }
        moneyVal = (int)moneySlider.value;

        money.text = moneySlider.value.ToString();
        UpdateValue();
    }

    public void OnHumanSliderValueChange()
    {
        int delta = (int)humanSlider.value- humanVal ;
        if (tempGlory - delta >= 0)
        {
            tempGlory -= delta;
        }
        else
        {
            int negative = tempGlory - delta;
            humanSlider.value += negative;
            tempGlory = 0;
        }
        humanVal = (int)humanSlider.value;
        human.text = humanSlider.value.ToString();
        UpdateValue();
    }

    public void OnBuildSliderValueChange()
    {

        int Value = (int)buildSlider.value;
        if (Value % 40 == 0)
        {
            int delta = (int)buildSlider.value - buildVal;

            if (tempGlory - delta >= 0)
            {
                tempGlory -= delta;
            }
            else
            { 
                 int negative = tempGlory - delta;
                 buildSlider.value += negative;
                 tempGlory = 0;
            }
            buildVal = (int)buildSlider.value;
            build.text = $"{buildSlider.value / 40} ({buildSlider.value.ToString()})";
            UpdateValue();
        }
        else if(Value %40 <5 )
        {
            int rest = Value - (40*(Value/40));
            buildSlider.value = Value - rest;
            int delta = (int)buildSlider.value - buildVal;
            if (tempGlory - delta >= 0)
            {
                tempGlory -= delta;
            }
            else
            {
                int negative = tempGlory - delta;
                buildSlider.value += negative;
                tempGlory = 0;
            }
            buildVal = (int)buildSlider.value;
            build.text = $"{buildSlider.value / 40} ({buildSlider.value.ToString()})";
            UpdateValue();

            //buildSlider.value = buildVal;
        }else if (Value % 40 > 5)
        {
            
            int rest =  (40 * ((Value / 40)+1)) - Value;
            if ((Value + rest) <= buildSlider.maxValue)
            {
                buildSlider.value = Value + rest;
                int delta = (int)buildSlider.value - buildVal;
                if (tempGlory - delta >= 0)
                {
                    tempGlory -= delta;
                }
                else
                {
                    int negative = tempGlory - delta;
                    buildSlider.value += negative;
                    tempGlory = 0;
                }
                buildVal = (int)buildSlider.value;
                build.text = $"{buildSlider.value/40} ({buildSlider.value.ToString()})";
                UpdateValue();
            }
            else
            {
                buildSlider.value = buildVal;
            }
        }
    }
}
