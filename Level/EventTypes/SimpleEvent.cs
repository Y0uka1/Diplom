using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvent :MonoBehaviour, ISectionEventType
{
    public GameObject interactObject { get ; set; }

    public void Initialize() { }

    public void OnInteract() { }


    public void TriggerEntered()
    {
        foreach (var i in MainManager.playersTeam.team)
        {
            i.morale -= 1;
        }
        MainManager.playersTeam.TorchLight -= 7;
        Debug.Log("Torch");
    }
}
