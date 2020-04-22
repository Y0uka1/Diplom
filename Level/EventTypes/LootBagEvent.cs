using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBagEvent :MonoBehaviour,  ISectionEventType
{
   public GameObject interactObject { get; set; }
   

    public void Initialize()
    {
        //interactObject = GetComponent<GameObject>();
        
        SpriteRenderer sprite = this.gameObject.AddComponent<SpriteRenderer>();
        sprite.sprite = Resources.Load<Sprite>("Sprites/LootBag");
    }

    public void OnInteract()
    {
        Debug.Log("+Money");
    }

    public void TriggerEntered() { }
}
