using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPauseCanvas : MonoBehaviour
{
    public Button Restart;
    public Button Options;
    public Button Quit;
    // Start is called before the first frame update
    void Start()
    {
        Restart.onClick.AddListener(RestartClick);
        Options.onClick.AddListener(OptionsClick);
        Quit.onClick.AddListener(QuitClick);
    }

    void RestartClick()
    {
        //le nom de la scène doit être récupéré dans le fichier save.txt
        string actualLevel = null;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "SelectionLevelScene" || scene.name == "MainMenuScene")
        {
            actualLevel = scene.name;
        }
        else
        {
            actualLevel = GetActualLevel();
        }
       
        if(actualLevel != null)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(actualLevel, LoadSceneMode.Single);
            Debug.Log("Restart launched");
        }
    }

    void OptionsClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(@"Scenes/OptionScene", LoadSceneMode.Single);
        Debug.Log("Options launched");
    }

    void QuitClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(@"Scenes/MainMenuScene", LoadSceneMode.Single);
        Debug.Log("Quit launched");
    }

    void OnGUI()
    {
        GUI.backgroundColor = new Color(0, 0, 0, 0.5F);
    }

    string GetActualLevel()
    {
        string lastLevel = null;
        using (Stream stream = File.Open("Assets/save.txt", FileMode.Open, FileAccess.Read))
        using (TextReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            lastLevel = reader.ReadLine();
        }
        return lastLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
