using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCollider : MonoBehaviour
{
  Player player;
  // Start is called before the first frame update
  void Start()
  {
    player = transform.parent.gameObject.GetComponent<Player>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    Vector2 dir = (coll.GetContact(0).point - (Vector2)transform.position);
    player.setWallSliding(true, (dir.x > 0) ? Vector2.right : Vector2.left);
  }

  void OnCollisionStay2D(Collision2D coll)
  {
    Vector2 dir = (coll.GetContact(0).point - (Vector2)transform.position);
    player.setWallSliding(true, (dir.x > 0) ? Vector2.right : Vector2.left);
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    player.setWallSliding(false, Vector2.zero);
  }
}
