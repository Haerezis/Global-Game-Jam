using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreselectionScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string lastLevel = null;
        using (Stream stream = File.Open("Assets/save.txt", FileMode.Open, FileAccess.Read))
        using (TextReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            lastLevel = reader.ReadLine();
        }

        if (lastLevel != null)
        {
            if (lastLevel == "lvl01_Squirrel")
            {
                transform.position = new Vector2(-1, -1);
            }
            //si il était à côté, il pop par défaut à côté du bouton Tuto
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
