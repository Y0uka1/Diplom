using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager: MonoBehaviour, IManager
{
    public  UIStats stats;
    public  BattleFeed feed;
    public  TurnPointer turnPointer;
    public  HealthBarManager healthBar;
    private GameObject CommonUI;
    private GameObject BattleUI;
    InventoryUI inventoryUI;
    CharsUI charsUI;

    public ManagerStatus status { get; set; } = ManagerStatus.Offline;

    public void Initialize()
    {
        stats = FindObjectOfType<UIStats>();
        feed = FindObjectOfType<BattleFeed>();
        turnPointer = FindObjectOfType<TurnPointer>();
        healthBar = GetComponent<HealthBarManager>();
        CommonUI = GameObject.FindGameObjectWithTag("CommonUI");
        BattleUI = GameObject.FindGameObjectWithTag("BattleUI");
        charsUI = GameObject.FindObjectOfType<CharsUI>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        // feed.Initialize();
        // stats.Initialize();
        // turnPointer.Initialize();
        //healthBar.Initialize();

        BattleUI.SetActive(false);
        status = ManagerStatus.Online;
        Debug.Log("UI manager onine");
        
    }

    public void InitializeCommonUI()
    {
        charsUI.Initialize();
        inventoryUI.Initialize();
        BattleUI.SetActive(false);
        CommonUI.SetActive(true);
        healthBar.Initialize();
    }

    public void InitializeBattleUI()
    {
        CommonUI.SetActive(false);
        BattleUI.SetActive(true);
      //  feed.Initialize();
        stats.Initialize();
        turnPointer.Initialize();
    }
}
