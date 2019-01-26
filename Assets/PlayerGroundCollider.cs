using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
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
    player.setGrounded(true);
  }

  void OnCollisionStay2D(Collision2D coll)
  {
    player.setGrounded(true);
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    player.setGrounded(false);
  }
}
