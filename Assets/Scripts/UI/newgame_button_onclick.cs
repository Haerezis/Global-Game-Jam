using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class newgame_button_onclick : MonoBehaviour
{

    public Button newgame;

    // Start is called before the first frame update
    void Start()
    {
        newgame.onClick.AddListener(NewGameOnClick);
    }

    // Update is called once per frame
    void NewGameOnClick()
    {
        //if (!Input.GetButtonDown("Jump"))
        //{
        //    using (Stream stream = File.Open("Assets/save.txt", FileMode.Truncate, FileAccess.Write))
        //    using (TextWriter wr = new StreamWriter(stream, Encoding.UTF8))
        //{
        //        wr.Write("lvl00_Tutorial");
        //        SceneManager.LoadScene("lvl00_Tutorial");
        //        Debug.Log("Rewritted file");
        //    }
        //}
        SceneManager.LoadScene("lvl00_Tutorial");
    }
}
