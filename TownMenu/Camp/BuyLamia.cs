using UnityEngine.UI;
using UnityEngine;

public class BuyLamia : ACBuyChar
{
    public override void BuyNewChar()
    {
        Debug.Log("Lam");
        LamiaChar chara = new LamiaChar(IDManager.GetID());
        CharactersSave.AddChar(chara);
        TownManager.charList.charList.Add(chara);
        base.BuyNewChar();
    }
}
