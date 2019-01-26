using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit_button_onclick : MonoBehaviour
{
    public Button exit;
    
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(ExitOnClick);
    }

    void ExitOnClick()
    {
        Application.Quit();
        Debug.Log("Application successfully quitted");
    }
}
