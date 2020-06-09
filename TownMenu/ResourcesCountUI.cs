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
        money.text = ResourcesManager.money.ToString();
        wepShard.text = ResourcesManager.weaponShard.ToString();
        wepChunk.text = ResourcesManager.weaponChunk.ToString();
        wepSlab.text = ResourcesManager.weaponSlab.ToString();
        armShard.text = ResourcesManager.armorShard.ToString();
        armChunk.text = ResourcesManager.armorChunck.ToString();
        armSlab.text = ResourcesManager.armorSlab.ToString();
        human.text = ResourcesManager.humans.ToString();
        build.text = ResourcesManager.buildMaterials.ToString();

    }

}
