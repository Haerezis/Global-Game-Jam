using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prompt_on_collide : MonoBehaviour
{

    private GameObject messageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        messageCanvas = this.gameObject.transform.Find("Canvas").gameObject;
        messageCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            messageCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
