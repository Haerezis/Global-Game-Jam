using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 positionInitiale;
    Vector3 positionFinale;
    Vector3 positionActuel;
    public float distance;
    public float velocity;
    float moveX;
    float moveY;
    public Direction direction;
    bool Isreturn = false;
    float velocityDirection;

    void Start()
    {
        positionInitiale = transform.position;
        positionFinale = positionInitiale;
        positionActuel = positionInitiale;
        velocityDirection = velocity;
        if (direction == Direction.UP)
        {
            moveX = 0;
            moveY = 1;
           positionFinale.y = positionInitiale.y + distance;
        }
        else if (direction == Direction.DOWN)
        {
            moveX = 0;
            moveY = -1;
            positionFinale.y = positionInitiale.y - distance;
        }
        else if (direction == Direction.LEFT)
        {
            moveX = -1;
            moveY = 0;
            positionFinale.x = positionInitiale.x - distance;
        }
        else
        {
            moveX = 1;
            moveY = 0;
            positionFinale.x = positionInitiale.x + distance;
        }

    }

    void Update()
    {
        CheckPosition();
        if (moveX != 0)
            positionActuel.x -= velocityDirection;
        else
            positionActuel.y -= velocityDirection;
        if (Isreturn == false)
            transform.position = Vector3.MoveTowards(transform.position, positionFinale, velocity);
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, positionInitiale, velocity);
        }
    }

    void CheckPosition()
    {
        if (moveX != 0)
        {
            if (moveX == -1)
            {
                if (positionActuel.x < positionFinale.x)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = true;
                }
                else if (positionActuel.x > positionInitiale.x)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = false;
                }
            }
            else
            {
                if (positionActuel.x > positionFinale.x)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = true;
                }
                else if (positionActuel.x < positionInitiale.x)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = false;
                }
            }
        }
        else
        {
            if (moveY == -1)
            {
                if (positionActuel.y < positionFinale.y)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = true;
                }
                else if (positionActuel.y > positionInitiale.y)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = false;
                }
            }
            else
            {
                if (positionActuel.y > positionFinale.y)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = true;
                }
                else if (positionActuel.y < positionInitiale.y)
                {
                    velocityDirection = -velocityDirection;
                    Isreturn = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Player player = coll.gameObject.GetComponent <Player> ();
            //if (player != null)
              //  player.(velocity);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Player player = coll.gameObject.GetComponent<Player>();
            //if (player != null)
              //  player.(velocity);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Player player = coll.gameObject.GetComponent<Player>();
            //if (player != null)
             //   player.(0.0f);
        }
    }
 
}