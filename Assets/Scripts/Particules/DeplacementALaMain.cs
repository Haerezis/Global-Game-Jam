using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementALaMain : MonoBehaviour
{
    public float speed = 1.5f;  //change this value to change speed
    public Direction direction;
    public float distance;
    private Vector3 positionInitiale;
    private Vector3 positionFinale;
    private Vector3 vectorGo;//si la plateforme va vers la gauche, alors vectorGo vaudra -1, 0, 0
    private Vector3 vectorReturn;//si la plateforme va vers la gauche, alors vectorReturn vaudra 1,0,0
    private bool isReturning;//indique si l'objet revient à sa position initiale

    private Rigidbody2D rb2D;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;
        isReturning = false;
        //distance = 5F;
        positionFinale = positionInitiale;
        if(direction == Direction.LEFT)
        {
            positionFinale.x = positionInitiale.x - distance;
            vectorGo = Vector3.left;
            vectorReturn = Vector3.right;
        }
        else if(direction == Direction.RIGHT)
        {
            positionFinale.x = positionInitiale.x + distance;
            vectorGo = Vector3.right;
            vectorReturn = Vector3.left;
        }
        else if(direction == Direction.UP)
        {
            positionFinale.y = positionInitiale.y + distance;
            vectorGo = Vector3.up;
            vectorReturn = Vector3.down;
        }
        else if (direction == Direction.DOWN)
        {
            positionFinale.y = positionInitiale.y - distance;
            vectorGo = Vector3.down;
            vectorReturn = Vector3.up;
        }
        //transform.position = new Vector3(5, 0, 0);
        //distance = positionInitiale.x - positionFinale.x;
        //rb2D = gameObject.AddComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Awake()
    {
        //Debug.Log("Awake");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //rb2D.velocity = new Vector2(25, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        //Vector3 positionFinale = new Vector3(-3, 2.6F, 0);
        var cestquoicettemerde = Vector3.Distance(positionFinale, transform.position);
        var lol = Vector3.Distance(positionInitiale, transform.position);
        if (isReturning == false)
        {
            if (Vector3.Distance(positionFinale, transform.position) > 0.2) //si on est arrivé au bout à gauche
            {
                //GetComponent<Rigidbody2D>().MovePosition(vectorGo * Time.deltaTime * speed);//cette ligne marche :)
                //transform.position = Vector3.MoveTowards(transform.position, positionFinale, Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody2D>().velocity = vectorGo;
            }
            else
            {
                //transform.Translate(Vector3.right * Time.deltaTime * speed);//cette ligne marche :)
                isReturning = true;
            }
        }
        else
        {
            if (Vector3.Distance(positionInitiale, transform.position) > 0.2) //si on est arrivé au bout à gauche
            {
                // GetComponent<Rigidbody2D>().MovePosition(vectorReturn * Time.deltaTime * speed);//cette ligne marche :)
                //transform.position = Vector3.MoveTowards(transform.position, positionInitiale, Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody2D>().velocity = vectorReturn;
            }
            else
            {
                //transform.Translate(Vector3.right * Time.deltaTime * speed);//cette ligne marche :)
                isReturning = false;
            }
        }
        
        
    }

    /*void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
        //var rigid = GetComponent<Rigidbody2D>();
        var test = new Vector2(25, 0);
        //rb2D.MovePosition(rb2D.position + new Vector2(-0.1F, 0));
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10F);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1F, 0);
    }*/

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

    //si il y a une collision, alors l'objet est détruit
}

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
