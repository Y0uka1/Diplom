using UnityEngine;

public class CampManager : ScriptableObject
{
    BuyArtorias artor;
    BuyLamia lamia;
    BuyDrida drida;


    public void Initialize()
    {
        artor = FindObjectOfType<BuyArtorias>();
        lamia = FindObjectOfType<BuyLamia>();
        drida = FindObjectOfType<BuyDrida>();
        artor.Initialize();
        lamia.Initialize();
        drida.Initialize();
    }
}
