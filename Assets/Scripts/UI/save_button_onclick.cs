using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class save_button_onclick : MonoBehaviour
{

    public Button save;
    public Slider musicSlider;


    // Start is called before the first frame update
    void Start()
    {
        save.onClick.AddListener(SaveOnClick);
    }

    // Update is called once per frame
    void SaveOnClick()
    {
        using (Stream stream = File.Open("Assets/config.cfg.txt", FileMode.Truncate, FileAccess.Write))
        using (TextWriter wr = new StreamWriter(stream, Encoding.UTF8))
        {
            wr.Write(musicSlider.value);
            Debug.Log("Volume set");
        }
        SceneManager.LoadScene("OptionScene");
    }
}
