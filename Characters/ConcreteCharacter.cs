using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteCharacter : MonoBehaviour
{
    ICharObject character;



    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ini(ICharObject chara)
    {
        SpriteRenderer sp = this.gameObject.AddComponent<SpriteRenderer>();
        sp.sprite = Resources.Load<Sprite>("Prefabs/ArtoriasStandBattle");
        character = chara;
       
    }
}
