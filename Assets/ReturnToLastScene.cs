using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToLastScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            /*using (Stream stream = File.Open("Assets/save.txt", FileMode.Truncate, FileAccess.Write))
            using (TextWriter wr = new StreamWriter(stream, Encoding.UTF8))
            {
                wr.Write("MainMenuScene");*/
            SceneManager.LoadScene(@"Scenes/MainMenuScene", LoadSceneMode.Single);
            //changer la commande pour aller à la scène précédente
            Debug.Log("Tuto launched");
            //}
        }
    }
}
