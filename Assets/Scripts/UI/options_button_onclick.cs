using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class options_button_onclick : MonoBehaviour
{

    public Button options;

    // Start is called before the first frame update
    void Start()
    {
        options.onClick.AddListener(OptionOnClick);
    }

    // Update is called once per frame
    void OptionOnClick()
    {
        if(!Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("OptionScene");
        }
    }
}
