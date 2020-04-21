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
    [SerializeField] EventType eventType=EventType.Simple;
    bool isActive=true;
    public void Initialize()
    {
        int randResult = Random.Range(0,2);
        if (randResult == 1)
        {
            eventType = (EventType)Random.Range(0,3);
        }    
    }

    void GenerateEventType()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.gameObject.tag == "PlayerTeam")
        {
            Debug.Log(eventType.ToString());
        }
    }

}
