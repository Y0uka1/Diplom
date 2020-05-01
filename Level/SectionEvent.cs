using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EventType
{
    Loot,
    Battle,
    Trap,
    Simple
}


public class SectionEvent : MonoBehaviour
{
    [SerializeField]  EventType eventType;
    ISectionEventType sectionEventType;
    System.Type[] lootEventType= { typeof(Event) };
    System.Type[] battleEventType = { typeof(Event) };
    System.Type[] TrapEventType = { typeof(Event) };
    


    bool isActive=true;
    public void Initialize()
    {
            eventType = (EventType)Random.Range(0,4);

            GenerateEventType();
    }

    private void GenerateEventType()
    {
        switch (eventType)
        {
            case EventType.Battle:
                 {
                    sectionEventType = this.gameObject.AddComponent<BattleEvent>();
                    break;
                 }

            case EventType.Loot:
                {
                    sectionEventType = this.gameObject.AddComponent<LootBagEvent>();
                    break;
                }
            case EventType.Trap:
                {
                    sectionEventType = this.gameObject.AddComponent<SimpleEvent>();
                    break;
                }
            case EventType.Simple:
                {
                    sectionEventType = this.gameObject.AddComponent<SimpleEvent>();
                    break;
                }

        }

        sectionEventType.Initialize();
      /*  if (sectionEventType.interactObject != null)
        {
            sectionEventType.interactObject.transform.position = this.gameObject.transform.position;
        }*/
    }

    private void OnMouseDown()
    {
        sectionEventType.OnInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerTeam")
        {
            sectionEventType.TriggerEntered();
        }
    }

}
