using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISectionEventType 
{
    GameObject interactObject { get; set; }
    bool isFinded { get; set; }
    bool isActivated { get; set; }

    void TorchAndMoraleLowering();

     void Initialize();
     void OnInteract();
     void TriggerEntered();
    
}
