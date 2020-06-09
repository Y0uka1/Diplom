using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIgnore : MonoBehaviour
{
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9,10);
        Physics2D.IgnoreLayerCollision(9, 11);
        Physics2D.IgnoreLayerCollision(11, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
