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

    List<GameObject> detailsList;

    void Start()
    {
        detailsList = new List<GameObject>();
        detailsList.Add(teamBuilderDetail);
        detailsList.Add(levelSelectDetail);
        teamBuilderMaster.onClick.AddListener(TeamBuilderMasterClicked);
        levelSelectMaster.onClick.AddListener(levelSelectMasterClicked);
        AllDetailHide();
        TeamBuilderMasterClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AllDetailHide()
    {
        foreach(var i in detailsList)
        {
            i.SetActive(false);
        }
    }

    private void TeamBuilderMasterClicked()
    {
        AllDetailHide();
        teamBuilderDetail.SetActive(true);
    }

    private void levelSelectMasterClicked()
    {
        AllDetailHide();
        levelSelectDetail.SetActive(true);
    }
}
