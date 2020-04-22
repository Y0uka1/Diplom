using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent :MonoBehaviour, ISectionEventType
{
    public GameObject interactObject { get; set; }

    public void Initialize()
    {
        //interactObject = GetComponent<GameObject>();
        SpriteRenderer sprite = this.gameObject.AddComponent<SpriteRenderer>();
        sprite.sprite = Resources.Load<Sprite>("Sprites/BattleEvent");
    }

    public void OnInteract()
    {
        Debug.Log("Battle");
    }

    public void TriggerEntered() { }
}
