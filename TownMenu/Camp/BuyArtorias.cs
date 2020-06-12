using UnityEngine;
using UnityEngine.UI;

public class BuyArtorias : ACBuyChar
{
    public override void BuyNewChar()
    {
        Debug.Log("Art");
        Artorias_Character chara = new Artorias_Character(IDManager.GetID());
        CharactersSave.AddChar(chara);
        TownManager.charList.charList.Add(chara);
        base.BuyNewChar();
    }

}
