using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaravanManager : ScriptableObject
{
    public  KaravanTrade trade;
    public  KaravanRequest request;
    public KaravanAccept acceptButton;

    public void Initialize()
    {
        trade = FindObjectOfType<KaravanTrade>();
        trade.Initialize();

        request = FindObjectOfType<KaravanRequest>();
        request.Initialize();

        acceptButton = FindObjectOfType<KaravanAccept>();
        acceptButton.Initialize();
    }

}
