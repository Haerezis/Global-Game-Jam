using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pikes : MonoBehaviour
{

    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Player player = coll.gameObject.GetComponent<Player>();
            if (player != null)
                player.kill();
            SceneManager.LoadScene(scene);
        }
    }
}
