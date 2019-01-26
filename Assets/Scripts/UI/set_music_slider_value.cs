using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class set_music_slider_value : MonoBehaviour
{

    public Slider musicSlider;
    public AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        using (Stream stream = File.Open("Assets/config.cfg.txt", FileMode.Open))
        using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
        {
            string volumeLevel;
            if ((volumeLevel = sr.ReadLine()) != null)
            {
                musicSlider.value = float.Parse(volumeLevel);
            }
            this.gameObject.GetComponent<Text>().text = "Music Volume : " + musicSlider.value;

            musicSlider.onValueChanged.AddListener(delegate { UpdateValue(); });
        }
    }

    public void UpdateValue()
    {
        this.gameObject.GetComponent<Text>().text = "Music Volume : " + musicSlider.value;
    }
}
