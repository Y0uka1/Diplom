using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationMaster : MonoBehaviour
{

    public Button teamBuilderMaster;
    public GameObject teamBuilderDetail;

    public Button levelSelectMaster;
    public GameObject levelSelectDetail;

    public Button forgeMaster;
    public GameObject forgeDetail;

    public Button tavernMaster;
    public GameObject tavernDetail;

    public Button karavanMaster;
    public GameObject karavanDetail;

    public Button campMaster;
    public GameObject campDetail;

    public List<GameObject> detailsList;

    ManagerStatus status = ManagerStatus.Offline;
   


    public void Initialize()
    {
        //   Debug.Log("NavigationMaster");
        if (status == ManagerStatus.Offline)
        {
            detailsList = new List<GameObject>();

            teamBuilderMaster = GameObject.Find("AllyListMaster").GetComponent<Button>();
            teamBuilderDetail = GameObject.Find("AllyListDetail");

            levelSelectMaster = GameObject.Find("LevelSelectMaster").GetComponent<Button>();
            levelSelectDetail = GameObject.Find("LevelSelectDetail");

            forgeMaster = GameObject.Find("ForgeMaster").GetComponent<Button>();
            forgeDetail = GameObject.Find("ForgeDetail");

            tavernMaster = GameObject.Find("TavernMaster").GetComponent<Button>();
            tavernDetail = GameObject.Find("TavernDetail");

            karavanMaster = GameObject.Find("KaravanMaster").GetComponent<Button>();
            karavanDetail = GameObject.Find("KaravanDetail");

            campMaster = GameObject.Find("CampMaster").GetComponent<Button>();
            campDetail = GameObject.Find("CampDetail");

            detailsList.Add(teamBuilderDetail);
            detailsList.Add(levelSelectDetail);
            detailsList.Add(forgeDetail);
            detailsList.Add(tavernDetail);
            detailsList.Add(karavanDetail);
            detailsList.Add(campDetail);
            teamBuilderMaster.onClick.AddListener(TeamBuilderMasterClicked);
            levelSelectMaster.onClick.AddListener(levelSelectMasterClicked);
            forgeMaster.onClick.AddListener(ForgeMasterClickerd);
            tavernMaster.onClick.AddListener(TavernMasterClicked);
            karavanMaster.onClick.AddListener(KaravanMasterClicked);
            campMaster.onClick.AddListener(CampMasterClicked);

            TownManager.Initialize();

            AllDetailHide(null);
            TeamBuilderMasterClicked();
        }
        status = ManagerStatus.Online;
    }

    private void CampMasterClicked()
    {
        AllDetailHide(campDetail);
        if (!campDetail.activeSelf)
        {
            campDetail.SetActive(true);
            TownManager.campManager.Initialize();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

     void AllDetailHide(GameObject curDetail)
    {
        foreach(var i in detailsList)
        {
            if(i!=curDetail)
            i.SetActive(false);
        }
    }

    private void TeamBuilderMasterClicked()
    {
        AllDetailHide(teamBuilderDetail);
        if (!teamBuilderDetail.activeSelf)
        {
            teamBuilderDetail.SetActive(true);
            TownManager.charList.Initialize();
            TownManager.teamBuilder.Initialize();
            TownManager.tbStats.Initialize();
            foreach (var i in GameObject.FindObjectsOfType<Placeholder>())
            {
                i.Initialize();
            }
        }
    }

    private void levelSelectMasterClicked()
    {
            AllDetailHide(levelSelectDetail);
        if (!levelSelectDetail.activeSelf)
        {
            levelSelectDetail.SetActive(true);
            TownManager.mapManager.Initialize();
        }
        
    }

    private void ForgeMasterClickerd()
    {
            AllDetailHide(forgeDetail);
        if (!forgeDetail.activeSelf)
        {
            forgeDetail.SetActive(true);
            TownManager.forgeList.Initialize();
            TownManager.equipmentManager.Initialize();
        }
    }

    private void TavernMasterClicked()
    {
        AllDetailHide(tavernDetail);
        if (!tavernDetail.activeSelf)
        {
            tavernDetail.SetActive(true);
            TownManager.tavernManager.Initialize();
        }
    }

    private void KaravanMasterClicked()
    {
        AllDetailHide(karavanDetail);
        if (!karavanDetail.activeSelf)
        {
            karavanDetail.SetActive(true);
            TownManager.karavanManager.Initialize();
        }
    }
}
