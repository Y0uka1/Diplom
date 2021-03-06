﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent :MonoBehaviour, ISectionEventType
{
    public GameObject interactObject { get; set; }
    public bool isActivated { get; set; } = false;
    public bool isFinded { get; set; } = false;
    public void Initialize()
    {
        //interactObject = GetComponent<GameObject>();
       // SpriteRenderer sprite = this.gameObject.AddComponent<SpriteRenderer>();
        //sprite.sprite = Resources.Load<Sprite>("Sprites/BattleEvent");
    }

    public void OnInteract()
    {
        if (isActivated == false)
        {
            Debug.Log("Battle");
            isActivated = true;
        }
    }

    public void TriggerEntered() {
        if (isFinded == false)
        {
            TorchAndMoraleLowering();
            MainManager.playersTeam.isInBattle = true;
            MainManager.battleManager.OnBattleStars();
            isFinded = true;
        }
    }

    public void TorchAndMoraleLowering()
    {
        int temp = MainManager.playersTeam.TorchLight;
        temp -= 7;
        MainManager.playersTeam.TorchLight = temp;
    }
}
