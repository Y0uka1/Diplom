using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager: MonoBehaviour, IManager
{
    public  UIStats stats;
    public  BattleFeed feed;
    public  TurnPointer turnPointer;
    public  HealthBarManager healthBar;

    public ManagerStatus status { get; set; } = ManagerStatus.Shutdown;

    public void Initialize()
    {
        stats = FindObjectOfType<UIStats>();
        feed = FindObjectOfType<BattleFeed>();
        turnPointer = FindObjectOfType<TurnPointer>();
        healthBar = GetComponent<HealthBarManager>();
        feed.Initialize();
        stats.Initialize();
        turnPointer.Initialize();
        healthBar.Initialize();
        status = ManagerStatus.Initialized;
        Debug.Log("UI manager onine");
    }
}
