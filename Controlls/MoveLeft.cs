using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   
    public Camera camera;
    public GameObject [] teamarr;
    public GameObject team;
    public void Initialize()
    {
        teamarr = new GameObject[4] {MainManager.playersTeam.team[0].link.gameObject, MainManager.playersTeam.team[1].link.gameObject,
            MainManager.playersTeam.team[2].link.gameObject, MainManager.playersTeam.team[3].link.gameObject };
        this.gameObject.layer = 11;
        Physics2D.IgnoreLayerCollision(9, 11);
    }

    private void OnMouseOver()
    {
        if (MainManager.playersTeam.isInBattle == false)
        {
            if (Input.GetMouseButton(0))
            {
                team.transform.position -= new Vector3(0.1f, 0);
                camera.transform.position -= new Vector3(0.1f, 0);
               
                teamarr[0].transform.position -= new Vector3(0.1f, 0);
                teamarr[1].transform.position -= new Vector3(0.1f, 0);
                teamarr[2].transform.position -= new Vector3(0.1f, 0);
                teamarr[3].transform.position -= new Vector3(0.1f, 0);

            }
        }
    }

   

}
