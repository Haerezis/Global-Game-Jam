using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleQuiBougePas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        //mettre du code que Thomas veut
        //Destroy(gameObject);
        ParticuleUtilisee();
    }

    void ParticuleUtilisee()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerEnter");
        //Destroy(collider.gameObject);
        //ParticuleUtilisee();
    }
}
