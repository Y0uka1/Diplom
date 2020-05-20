using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools 
{
    public static System.Type EnumToCharClass(CharClassEnum type)
    {
        switch (type)
        {
            case CharClassEnum.Artorias:
                {
                    return typeof(Artorias_Character);
                }
            case CharClassEnum.Lamia:
                {
                    return typeof(LamiaChar);
                }
            default:
                {
                    return typeof(EnemyTest1);
                }
        }
    }
}
