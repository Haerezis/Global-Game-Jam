using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadCollider : MonoBehaviour
{
  Player player;

  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    player.OnHeadTriggerEnter(coll);
  }

  void OnTriggerStay2D(Collider2D coll)
  {
    player.OnHeadTriggerStay(coll);
  }

}
