using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaravanTrade : MonoBehaviour
{
    GameObject wep1Trade;
    Text wep1Price;
    Button wep1LeftButton;
    Button wep1RightButton;
    Text wep1Count;

    GameObject wep2Trade;
    Text wep2Price;
    Button wep2LeftButton;
    Button wep2RightButton;
    Text wep2Count;

    GameObject wep3Trade;
    Text wep3Price;
    Button wep3LeftButton;
    Button wep3RightButton;
    Text wep3Count;

    GameObject arm1Trade;
    Text arm1Price;
    Button arm1LeftButton;
    Button arm1RightButton;
    Text arm1Count;

    GameObject arm2Trade;
    Text arm2Price;
    Button arm2LeftButton;
    Button arm2RightButton;
    Text arm2Count;

    GameObject arm3Trade;
    Text arm3Price;
    Button arm3LeftButton;
    Button arm3RightButton;
    Text arm3Count;

    Text gloryCount;

    public int wep1CountInt =0;
    public int wep2CountInt =0;
    public int wep3CountInt =0;
    public int arm1CountInt =0;
    public int arm2CountInt =0;
    public int arm3CountInt =0;
    public int gloryCountInt =100;


    public void Initialize()
    {
        wep1Trade = GameObject.Find("wep1Trade");
        wep1Price = wep1Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        wep1LeftButton = wep1Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        wep1RightButton = wep1Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        wep1Count = wep1Trade.transform.GetChild(3).gameObject.GetComponent<Text>();
        wep1Count.text = wep1CountInt.ToString();

        wep1LeftButton.onClick.AddListener(() =>
        {
            if (wep1CountInt > 0)
            {
                wep1CountInt--;
                wep1Count.text = wep1CountInt.ToString();
            }
        });

        wep1RightButton.onClick.AddListener(() =>
        {

            wep1CountInt++;
            wep1Count.text = wep1CountInt.ToString();

        });

        wep2Trade = GameObject.Find("wep2Trade");
        wep2Price = wep2Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        wep2LeftButton = wep2Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        wep2RightButton = wep2Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        wep2Count = wep2Trade.transform.GetChild(3).gameObject.GetComponent<Text>();
        wep2Count.text = wep3CountInt.ToString();

        wep2LeftButton.onClick.AddListener(() =>
        {
            if (wep2CountInt > 0)
            {
                wep2CountInt--;
                wep2Count.text = wep2CountInt.ToString();
            }
        });

        wep2RightButton.onClick.AddListener(() =>
        {

            wep2CountInt++;
            wep2Count.text = wep2CountInt.ToString();

        });

        wep3Trade = GameObject.Find("wep3Trade");
        wep3Price = wep3Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        wep3LeftButton = wep3Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        wep3RightButton = wep3Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        wep3Count = wep3Trade.transform.GetChild(3).gameObject.GetComponent<Text>();
        wep3Count.text = wep3CountInt.ToString();

        wep3LeftButton.onClick.AddListener(() =>
        {
            if (wep3CountInt > 0)
            {
                wep3CountInt--;
                wep3Count.text = wep3CountInt.ToString();
            }
        });

        wep3RightButton.onClick.AddListener(() =>
        {

            wep3CountInt++;
            wep3Count.text = wep3CountInt.ToString();

        });

        arm1Trade = GameObject.Find("arm1Trade");
        arm1Price = arm1Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        arm1LeftButton = arm1Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        arm1RightButton = arm1Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        arm1Count = arm1Trade.transform.GetChild(3).gameObject.GetComponent<Text>();
        arm1Count.text = arm1CountInt.ToString();

        arm1LeftButton.onClick.AddListener(() =>
        {
            if (arm1CountInt > 0)
            {
                arm1CountInt--;
                arm1Count.text = arm1CountInt.ToString();
            }
        });

        arm1RightButton.onClick.AddListener(() =>
        {

            arm1CountInt++;
            arm1Count.text = arm1CountInt.ToString();

        });

        arm2Trade = GameObject.Find("arm2Trade");
        arm2Price = arm2Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        arm2LeftButton = arm2Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        arm2RightButton = arm2Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        arm2Count = arm2Trade.transform.GetChild(3).gameObject.GetComponent<Text>();

        arm2Count.text = arm2CountInt.ToString();

        arm2LeftButton.onClick.AddListener(() =>
        {
            if (arm2CountInt > 0)
            {
                arm2CountInt--;
                arm2Count.text = arm2CountInt.ToString();
            }
        });

        arm2RightButton.onClick.AddListener(() =>
        {

            arm2CountInt++;
            arm2Count.text = arm2CountInt.ToString();

        });

        arm3Trade = GameObject.Find("arm3Trade");
        arm3Price = arm3Trade.transform.GetChild(0).gameObject.GetComponent<Text>();
        arm3LeftButton = arm3Trade.transform.GetChild(1).gameObject.GetComponent<Button>();
        arm3RightButton = arm3Trade.transform.GetChild(2).gameObject.GetComponent<Button>();
        arm3Count = arm3Trade.transform.GetChild(3).gameObject.GetComponent<Text>();
        arm3Count.text = arm3CountInt.ToString();

        arm3LeftButton.onClick.AddListener(() =>
        {
            if (arm3CountInt > 0)
            {
                arm3CountInt--;
                arm3Count.text = arm3CountInt.ToString();
            }
        });

        arm3RightButton.onClick.AddListener(() =>
        {
           
                arm3CountInt++;
                arm3Count.text = arm3CountInt.ToString();
            
        });

        gloryCountInt = ResourcesManager.glory;

        gloryCount = GameObject.Find("GloryCount").GetComponent<Text>();
        gloryCount.text = gloryCountInt.ToString();


        PriceIni();

    }


    void PriceIni()
    {
        wep1Price.text = "500";
        wep2Price.text = "1000";
        wep3Price.text = "1500";

        arm1Price.text = "500";
        arm2Price.text = "1000";
        arm3Price.text = "1500";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
