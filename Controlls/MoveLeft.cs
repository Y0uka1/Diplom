﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   
    public Camera camera;
    public GameObject team;

    private void OnMouseOver()
    {
        if (MainManager.playersTeam.isInBattle == false)
        {
            if (Input.GetMouseButton(0))
            {
                team.transform.position -= new Vector3(0.1f, 0);
                camera.transform.position -= new Vector3(0.1f, 0);
            }
        }
    }

   

}
