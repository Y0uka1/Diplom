using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    public static void Initialize()
    {
        float x = -3.8f;
        foreach (var i in MainManager.playersTeam.team)
        {
            GameObject temp = new GameObject();
            Vector3 pos = new Vector3(x, 3, 0);
            temp.transform.position = pos;
            System.Type type = i.type;
            var chara = temp.AddComponent(type) as ICharObject;

            chara.Initialize(i);
            
           // Instantiate(temp, pos, new Quaternion(0, 0, 0, 0));         
            x -= 3.8f;
        }

        x = 3.8f;

        MainManager.enemyTeam.CreateEnemyTeam();

        foreach (var i in MainManager.enemyTeam.team)
        {
            GameObject temp = new GameObject();
            Vector3 pos = new Vector3(x, 3, 0);
            temp.transform.position = pos;
            System.Type type = i.type;
            var chara = temp.AddComponent(type) as ICharObject;

            chara.Initialize(i);
            // Instantiate(temp, pos, new Quaternion(0, 0, 0, 0));
            x += 3.8f;
        }


    }
}
