using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISectionEventType 
{
    GameObject interactObject { get; set; }
     void Initialize();
     void OnInteract();
     void TriggerEntered();
    
}
