using UnityEngine.UI;
using UnityEngine;

public class BuyDrida : ACBuyChar
{
    public override void BuyNewChar()
    {
        Debug.Log("Dri");
        DridaCharacter chara = new DridaCharacter(IDManager.GetID());
        CharactersSave.AddChar(chara);
        TownManager.charList.charList.Add(chara);
        base.BuyNewChar();
    }
}
