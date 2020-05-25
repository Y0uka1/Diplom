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

    List<GameObject> detailsList;

    

    public void Initialize()
    {
        Debug.Log("NavigationMaster");
        detailsList = new List<GameObject>();

        teamBuilderMaster = GameObject.Find("AllyListMaster").GetComponent<Button>();
        teamBuilderDetail = GameObject.Find("AllyListDetail");

        levelSelectMaster = GameObject.Find("LevelSelectMaster").GetComponent<Button>();
        levelSelectDetail = GameObject.Find("LevelSelectDetail");

        forgeMaster = GameObject.Find("ForgeMaster").GetComponent<Button>();
        forgeDetail = GameObject.Find("ForgeDetail");


        detailsList.Add(teamBuilderDetail);
        detailsList.Add(levelSelectDetail);
        detailsList.Add(forgeDetail);
        teamBuilderMaster.onClick.AddListener(TeamBuilderMasterClicked);
        levelSelectMaster.onClick.AddListener(levelSelectMasterClicked);
        forgeMaster.onClick.AddListener(ForgeMasterClickerd);


        TownManager.Initialize();
        
        AllDetailHide(null);
        TeamBuilderMasterClicked();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AllDetailHide(GameObject curDetail)
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
}
