using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    public Button launchTuto;
    // Start is called before the first frame update
    void Start()
    {
        launchTuto.onClick.AddListener(StartTuto);
        
    }

    void StartTuto()
    {
        if (Input.GetButtonDown("Submit"))
        {
            /*using (Stream stream = File.Open("Assets/save.txt", FileMode.Truncate, FileAccess.Write))
            using (TextWriter wr = new StreamWriter(stream, Encoding.UTF8))
            {
                wr.Write("MainMenuScene");*/
                SceneManager.LoadScene(@"Scenes/lvl00_Tutorial", LoadSceneMode.Single);
                Debug.Log("Tuto launched");
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
