using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class continue_button_onclick : MonoBehaviour
{
    
    public Button cont;
    
    // Start is called before the first frame update
    void Start()
    {
        cont.onClick.AddListener(ContinueOnClick);
    }

    // Update is called once per frame
    void ContinueOnClick()
    {
        if (!(Input.GetButtonDown("Jump")))
        {
            //using (Stream stream = File.Open("Assets/save.txt", FileMode.Open))
            //using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
            //{
            //    string levelScene;
            //    if ((levelScene = sr.ReadLine()) != null)
            //    {
            //        SceneManager.LoadScene(levelScene);
            //        Debug.Log("SceneLoaded");
            //    }
            //}
            SceneManager.LoadScene("lvl00_Tutorial");
        }
    }
}
