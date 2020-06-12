using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public Camera camera;
    public GameObject[] teamarr;
    public GameObject team;
    public BoxCollider2D collider;
    public void Initialize()
    {
        try
        {
            teamarr = new GameObject[4] {MainManager.playersTeam.team[0].link.gameObject, MainManager.playersTeam.team[1].link.gameObject,
            MainManager.playersTeam.team[2].link.gameObject, MainManager.playersTeam.team[3].link.gameObject };
        }
        catch
        {
            teamarr = new GameObject[4];
            if (MainManager.playersTeam.team[0] != null)
                teamarr[0] = MainManager.playersTeam.team[0].link.gameObject;
            if (MainManager.playersTeam.team[1] != null)
                teamarr[0] = MainManager.playersTeam.team[1].link.gameObject;
            if (MainManager.playersTeam.team[2] != null)
                teamarr[0] = MainManager.playersTeam.team[2].link.gameObject;
            if (MainManager.playersTeam.team[3] != null)
                teamarr[0] = MainManager.playersTeam.team[3].link.gameObject;
        }
        this.gameObject.layer = 11;
        Physics2D.IgnoreLayerCollision(9, 11);
        collider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseOver()
    {
        if (MainManager.playersTeam.isInBattle == false)
        {
            if (Input.GetMouseButton(0))
            {
                team.transform.position += new Vector3(0.1f, 0);
                camera.transform.position += new Vector3(0.1f, 0);
                if(teamarr[0]!=null)
                    teamarr[0].transform.position += new Vector3(0.1f, 0);
                if (teamarr[1] != null)
                    teamarr[1].transform.position += new Vector3(0.1f, 0);
                if (teamarr[2] != null)
                    teamarr[2].transform.position += new Vector3(0.1f, 0);
                if (teamarr[3] != null)
                    teamarr[3].transform.position += new Vector3(0.1f, 0);
            }
        }
    }
   
}
