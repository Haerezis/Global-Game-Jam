using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 1.5f;  //change this value to change speed
    public Direction direction;
    public float distance;
    private Vector3 positionInitiale;
    private Vector3 positionFinale;
    private Vector3 vectorGo;//si la plateforme va vers la gauche, alors vectorGo vaudra -1, 0, 0
    private Vector3 vectorReturn;//si la plateforme va vers la gauche, alors vectorReturn vaudra 1,0,0
    private bool isReturning;//indique si l'objet revient à sa position initiale

    private bool facing_right = false;
    private Rigidbody2D rb2D;
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
    }

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturning == false)
        {
            if (Vector3.Distance(positionFinale, transform.position) > 0.2) //si on est arrivé au bout à gauche
            {
                this.rb2D.velocity = vectorGo;
            }
            else
            {
                isReturning = true;
            }
        }
        else
        {
            if (Vector3.Distance(positionInitiale, transform.position) > 0.2) //si on est arrivé au bout à gauche
            {
                rb2D.velocity = vectorReturn;
            }
            else
            {
                isReturning = false;
            }
        }

        if ((rb2D.velocity.x > 0) && !facing_right) {
          flip();
        }
        else if ((rb2D.velocity.x < 0) && facing_right) {
          flip();
        }
    }


    // Flip the localScale of the player (to reuse same sprite when going left & right).
    protected void flip() {
      // Switch the way the player is labelled as facing.
      facing_right = !facing_right;

      // Multiply the player's x local scale by -1.
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
}

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
