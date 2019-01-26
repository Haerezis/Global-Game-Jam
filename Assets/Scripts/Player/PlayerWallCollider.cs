using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCollider : MonoBehaviour
{
  Player player;

  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    player.OnWallCollisionEnter(coll);
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    player.OnWallCollisionExit(coll);
  }
}
