using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootManager : MonoBehaviour
{
    public static int level;


    public static void BattleLoot()
    {
        System.Random rand = new System.Random();
        switch (level)
        {
            case 1:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 25);
                    MainManager.inventory.ResAdd (ResourceTypes.Money, rand.Next(100, 250));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(100, 250));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 1));
                    break;
                }
            case 2:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 50);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, rand.Next(400, 700));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(400, 700));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 2));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 2));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, rand.Next(0, 1));
                    break;
                }
            case 3:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 75);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, rand.Next(800, 1000));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(800, 1000));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 3));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 3));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck, rand.Next(0, 2));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, rand.Next(0, 2));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponSlab, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorSlab, rand.Next(0, 1));
                    break;
                }
           
        }

       
    }

    public static void BossLoot()
    {
        System.Random rand = new System.Random();
        switch (level)
        {
            case 1:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 100);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, 1500);
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(1000, 1500));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, 4);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, 4);
                    break;
                }
            case 2:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 150);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, 2500);
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(1500, 2500));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, 4);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, 4);
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck, 3);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, 3);
                    break;
                }
            case 3:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 200);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, 3000);
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(2500, 3000));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, 8);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, 8);
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck,4);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, 4);
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponSlab, 2);
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorSlab, 2);
                    break;
                }
           
        }


    }

    public static void LootBag()
    {
        System.Random rand = new System.Random();
        switch (level)
        {
            case 1:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Money, rand.Next(50, 100));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(25, 50));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 1));
                    break;
                }
            case 2:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 50);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, rand.Next(200, 300));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(100, 150));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, rand.Next(0, 1));
                    break;
                }
            case 3:
                {
                    MainManager.inventory.ResAdd(ResourceTypes.Glory, 75);
                    MainManager.inventory.ResAdd(ResourceTypes.Money, rand.Next(300, 400));
                    MainManager.inventory.ResAdd(ResourceTypes.BuildingMaterials, rand.Next(150, 200));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorShard, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponChunck, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorChunck, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.WeaponSlab, rand.Next(0, 1));
                    MainManager.inventory.ResAdd(ResourceTypes.ArmorSlab, rand.Next(0, 1));
                    break;
                }


        }
    }

    
}
