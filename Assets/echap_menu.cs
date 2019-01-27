using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class echap_menu : MonoBehaviour
{

    private bool menuLoaded;

    void Start()
    {
        menuLoaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (menuLoaded)
            {
                CloseMenu();
                menuLoaded = false;
            }
            else
            {
                OverloadMenu();
                menuLoaded = true;
            }
            
        }
    }

    void OverloadMenu()
    {
        Time.timeScale = 0;
        //GUI.backgroundColor = Color.black;
        SceneManager.LoadScene("EchapMenu", LoadSceneMode.Additive);
    }

    void CloseMenu()
    {
        //GUI.backgroundColor = ;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("EchapMenu");
    }
}
