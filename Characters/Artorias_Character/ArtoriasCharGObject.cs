using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtoriasCharGObject : ICharObject
{
    public ICharacterStats character;
    public string prefabWay  = "Prefabs/ArtoriasPrefab";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("select");
        OnClicked();
    }
    public void OnClicked()
    {
        if (MainManager.battleManager.currentTurn == TurnType.Player)
        {
            if (MainManager.battleManager.skill != null)
            {
                if (character.charType == CharacterType.Enemy)
                {
                    MainManager.battleManager.target = character;
                    MainManager.battleManager.OnTargetReady();
                }
            }
        }
    }
   /* public void OnTurnChanges()
    {
        if (MainManager.battleManager.currentChar == character)
        {
            Debug.Log(name);
        }
    }*/
    public override void Initialize(ICharacterStats character)
    {
        SpriteRenderer sp = gameObject.AddComponent<SpriteRenderer>();
        sp.sprite = Resources.Load<Sprite>("Prefabs/ArtoriasStandBattle");
        gameObject.AddComponent<BoxCollider2D>();
        
        this.character = character;
        this.character.link = this;
       /* HealthBarManager hBar = gameObject.AddComponent<HealthBarManager>();
        hBar.Initialize(character);
        hBar.RefreshPos();*/
        //MainManager.battleManager.OnTurnChangesEvent += OnTurnChanges;
    }
}
