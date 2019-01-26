using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainmenu_button_onclick : MonoBehaviour
{

    public Button mainmenu;
    
    // Start is called before the first frame update
    void Start()
    {
        mainmenu.onClick.AddListener(MainMenuOnClick);
    }

    // Update is called once per frame
    void MainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
