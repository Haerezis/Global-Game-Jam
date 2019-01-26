using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchLevel01 : MonoBehaviour
{
    public Button launchLevel;
    // Start is called before the first frame update
    void Start()
    {
        launchLevel.onClick.AddListener(StartLevel);
    }

    void StartLevel()
    {
        if (Input.GetButtonDown("Submit"))
        {
            /*using (Stream stream = File.Open("Assets/save.txt", FileMode.Truncate, FileAccess.Write))
            using (TextWriter wr = new StreamWriter(stream, Encoding.UTF8))
            {
                wr.Write("MainMenuScene");*/
            SceneManager.LoadScene(@"Scenes/lvl01_Squirrel", LoadSceneMode.Single);
            Debug.Log("Level 01 launched");
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
