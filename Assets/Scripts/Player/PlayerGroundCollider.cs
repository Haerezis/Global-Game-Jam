using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
  Player player;

  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    player.OnGroundCollisionEnter(coll);
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    player.OnGroundCollisionExit(coll);
  }
}
