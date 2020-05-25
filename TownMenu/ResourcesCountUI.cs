using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesCountUI : MonoBehaviour
{
    public Text money;
    public Text wepShard;
    public Text wepChunk;
    public Text wepSlab;
    public Text armShard;
    public Text armChunk;
    public Text armSlab;
    public Text human;
    public Text build;


    public void Initialize()
    {
        money.text = MainManager.resourcesData.money.ToString();
        wepShard.text = MainManager.resourcesData.weaponShard.ToString();
        wepChunk.text = MainManager.resourcesData.weaponChunk.ToString();
        wepSlab.text = MainManager.resourcesData.weaponSlab.ToString();
        armShard.text = MainManager.resourcesData.armorShard.ToString();
        armChunk.text = MainManager.resourcesData.armorChunck.ToString();
        armSlab.text = MainManager.resourcesData.armorSlab.ToString();
        human.text = MainManager.resourcesData.humans.ToString();
        build.text = MainManager.resourcesData.buildMaterials.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
