using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameObject team;

    private void Start()
    {
        team = GameObject.FindGameObjectWithTag("PlayerTeam");
        float x = -3.8f;
        foreach (var i in MainManager.playersTeam.team)
        {
            GameObject temp = new GameObject();
            temp.transform.SetParent(team.transform);
            Vector3 pos = new Vector3(x, 1, 0);
            temp.transform.position = pos;
            System.Type type = i.type;
            var chara = temp.AddComponent(type) as ICharObject;

            chara.Initialize(i);

            // Instantiate(temp, pos, new Quaternion(0, 0, 0, 0));         
            x -= 3.8f;
        }

        x = 3.8f;
        MainManager.playersTeam.torchBar = FindObjectOfType<TorchBar>();
        MainManager.ui.Initialize();
        MainManager.ui.InitializeCommonUI();
    }
}
