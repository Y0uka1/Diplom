using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameObject team;

    private void Start()
    {
        team = GameObject.FindGameObjectWithTag("PlayerTeam");
        float x = -13f;
       
        foreach (var i in MainManager.playersTeam.team)
        {
            if (i != null)
            {
                GameObject temp = new GameObject();
                //temp.transform.SetParent(team.transform);
                Vector3 pos = new Vector3(x, 1, 0);
                temp.transform.position = pos;
                System.Type type = i.type;
                var chara = temp.AddComponent(type) as ICharObject;
                BoxCollider2D collider = temp.AddComponent<BoxCollider2D>();
                collider.offset = Vector2.zero;
                collider.size = new Vector2(4, 5);
                temp.layer = 9;
                chara.Initialize(i);
            }
            // Instantiate(temp, pos, new Quaternion(0, 0, 0, 0));         
            x += 3f;
            
        }

        x = 1f;
        MainManager.playersTeam.torchBar = FindObjectOfType<TorchBar>();
        MainManager.ui.Initialize();
        MainManager.ui.InitializeCommonUI();

        FindObjectOfType<MoveLeft>().Initialize();
        FindObjectOfType<MoveRight>().Initialize();

    }
}
