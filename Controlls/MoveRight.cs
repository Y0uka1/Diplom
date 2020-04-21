using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public Camera camera;
    public GameObject team;


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            team.transform.position += new Vector3(0.1f, 0);
            camera.transform.position += new Vector3(0.1f, 0);
        }
    }
   
}
