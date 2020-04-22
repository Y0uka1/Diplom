using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    GameObject startSection;
    
    void Initialize()
    {
        startSection = GameObject.Find("LevelStart");
        GenerateSections();
    }

    void GenerateSections()
    {
        GameObject temp;
        Vector2 curPosition = startSection.transform.position;
        for (int i = 0; i < 8; i++)
        {
           
            temp = new GameObject();
            BoxCollider2D collider = temp.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(6, 6);
            collider.isTrigger = true;
            //temp.layer = 2;
            SectionEvent se = temp.AddComponent<SectionEvent>();
            temp.transform.position = new Vector3(curPosition.x + 6.2f, curPosition.y);
            se.Initialize();
            curPosition = temp.transform.position;
        }
    }

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
