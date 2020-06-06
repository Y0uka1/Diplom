using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaravanManager : ScriptableObject
{
    public static KaravanTrade trade;
    public static KaravanRequest request;

    public void Initialize()
    {
        trade = FindObjectOfType<KaravanTrade>();
        trade.Initialize();

        request = FindObjectOfType<KaravanRequest>();
        request.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
