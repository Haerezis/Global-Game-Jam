using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [Header("Movement")]
  public float horizontal_ground_speed = 1.0f;
  [Range(0, 1f)]
  public float ground_drag = 0.05f;
  [Header("Jump")]
  public float jump_speed = 1.0f;
  public float horizontal_air_speed = 1.0f;
  public float gravity_coefficient = 1.0f;
  [Range(0, 1f)]
  public float air_drag = 0.05f;

  // constants:
  // BLA BLAH

  // state:
  protected Vector2 velocity;

  protected bool grounded = false;
  protected bool wallSliding = false;
  protected bool jumping = false;

  // inputs:
  protected Vector2 input;

  // misc:
  protected Rigidbody2D rgbd;

  void Awake() {
    this.rgbd = this.gameObject.GetComponent<Rigidbody2D>();
  }
  
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    ComputeVelocity();
  }

  protected void ComputeVelocity()
  {
    float x_movement = Input.GetAxis ("Horizontal");

    if (Mathf.Abs(x_movement) >= 0.05f) {
      if (grounded) {
        velocity.x = x_movement * horizontal_ground_speed;
      }
      else {
        velocity.x = x_movement * horizontal_air_speed;
      }
    }

    if (grounded) {
      velocity.x *= 1.0f - ground_drag;
    }
    else {
      velocity.x *= 1.0f - air_drag;
    }


    if (Input.GetButtonDown ("Jump")) {
      if (grounded) {
        velocity.y = jump_speed;
      }
    }

    // gravity:
    if (!grounded) {
      velocity += Physics2D.gravity * gravity_coefficient * Time.deltaTime;
    }
    else if (velocity.y < 0) {
      velocity.y = 0.0f;
    }

    rgbd.MovePosition(rgbd.position + velocity * Time.deltaTime);
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) grounded = true;
  }

  void OnCollisionStay2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) grounded = true;
  }

  void OnCollisionExit2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Ground")) grounded = false;
  }
}
