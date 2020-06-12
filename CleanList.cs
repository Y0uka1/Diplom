using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CleanList : MonoBehaviour
{
   void Start()
    {
        File.Delete(Application.persistentDataPath + "Characters.txt");
        File.Delete(Application.persistentDataPath + "lastID.txt");
    }
}
