using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResRed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResourcesData res = new ResourcesData();

        res.money = 50000;
        res.weaponChunk = 500;
        res.weaponShard = 500;
        res.weaponSlab = 500;
        res.armorShard = 500;
        res.armorChunck = 500;
        res.armorSlab = 500;
        res.humans = 500;
        res.buildMaterials = 50000;
        res.glory = 500;

        string tmp = JsonUtility.ToJson(res);
        File.WriteAllText(Application.persistentDataPath + "townResources.txt", tmp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
