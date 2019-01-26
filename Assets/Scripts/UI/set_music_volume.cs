using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class set_music_volume : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        using (Stream stream = File.Open("Assets/config.cfg.txt", FileMode.Open))
        using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
        {
            string volumeLevel;
            if ((volumeLevel = sr.ReadLine()) != null)
            {
                this.gameObject.GetComponent<AudioSource>().volume = float.Parse(volumeLevel) / 100;
            }
        }
    }
}
