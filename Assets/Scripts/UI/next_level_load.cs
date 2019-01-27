using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class next_level_load : MonoBehaviour
{
    
    public Button nextLevel;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.onClick.AddListener(NextLevelOnClick);
    }

    void NextLevelOnClick()
    {
        SceneManager.LoadScene(nextScene);
    }
}
