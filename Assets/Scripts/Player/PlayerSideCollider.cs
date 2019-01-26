using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideCollider : MonoBehaviour
{
  Player player;

  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    player.OnSideTriggerEnter(coll);
  }

  void OnTriggerStay2D(Collider2D coll)
  {
    player.OnSideTriggerStay(coll);
  }

  void OnTriggerExit2D(Collider2D coll)
  {
    player.OnSideTriggerExit(coll);
  }
}
