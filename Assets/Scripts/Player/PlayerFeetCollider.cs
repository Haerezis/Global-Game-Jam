using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetCollider : MonoBehaviour
{
  Player player;

  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    player.OnFeetTriggerEnter(coll);
  }

  void OnTriggerStay2D(Collider2D coll)
  {
    player.OnFeetTriggerStay(coll);
  }

  void OnTriggerExit2D(Collider2D coll)
  {
    player.OnFeetTriggerExit(coll);
  }
}
