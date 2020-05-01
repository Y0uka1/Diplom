using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvent :MonoBehaviour, ISectionEventType
{
    public GameObject interactObject { get ; set; }
    public bool isActivated { get; set; } = false;
    public bool isFinded { get; set; } = false;

    public void Initialize() { }

    public void OnInteract() { }


    public void TriggerEntered()
    {
        /*foreach (var i in MainManager.playersTeam.team)
        {
            i.morale -= 1;
        }*/
        if (isFinded == false)
        {
            TorchAndMoraleLowering();
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
