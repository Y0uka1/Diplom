﻿using System.Collections;
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
        for (int i = 0; i < 21; i++)
        {
           
            temp = new GameObject();
            temp.layer = 10;
            BoxCollider2D collider = temp.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(6, 6);
            collider.isTrigger = true;
            //temp.layer = 2;
            SectionEvent se = temp.AddComponent<SectionEvent>();
            temp.transform.position = new Vector3(curPosition.x + 6.2f, curPosition.y, 20);
            se.Initialize();
            curPosition = temp.transform.position;
        }

        temp = new GameObject();
        temp.layer = 10;
        BoxCollider2D colliderr = temp.AddComponent<BoxCollider2D>();
        colliderr.size = new Vector2(6, 6);
        colliderr.isTrigger = true;
        //temp.layer = 2;
        LevelEnd see = temp.AddComponent<LevelEnd>();
        temp.transform.position = new Vector3(curPosition.x + 6.2f, curPosition.y, 20);
        see.Initialize();
        
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
