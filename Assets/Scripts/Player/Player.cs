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
  public float max_fall_speed = 30.0f;
  [Header("Air Jump")]
  // air_jump_speed => jump_speed * air_jump_speed_coeff
  public float air_jump_speed_coefficient = 1.0f;
  public float wall_jump_speed_y = 1.0f;
  public float wall_jump_speed_x = 1.0f;

  // constants:
  // BLA BLAH

  // state:
  protected Vector2 velocity;

  protected bool grounded = false;
  protected bool wall_sliding = false;
  protected Vector2 wall_side;
  protected bool has_air_jumped = false;

  // inputs:
  protected Vector2 input;

  // misc:
  protected Rigidbody2D rgbd;
  protected ContactPoint2D[] contacts = new ContactPoint2D[10];

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

    // Handle Jumps (normal, air, wall)
    if (Input.GetButtonDown ("Jump")) {
      if (wall_sliding) {
        velocity.x = wall_jump_speed_x * (-1) * wall_side.x;
        velocity.y = wall_jump_speed_y;
      }
      else if (grounded) {
        velocity.y = jump_speed;
      }
      else if (!has_air_jumped) {
        velocity.y = jump_speed * air_jump_speed_coefficient;
        has_air_jumped = true;
      }
    }

    // gravity:
    if (!grounded) {
      velocity += Physics2D.gravity * gravity_coefficient;
    }
    else if (velocity.y < 0) {
      velocity.y = 0.0f;
    }

    //Handle max fall speed.
    if (velocity.y < -max_fall_speed) {
      velocity.y = -max_fall_speed;
    }

    rgbd.velocity = velocity;
  }
  
  public void setGrounded(bool val) {
    this.grounded = val;

    if (!this.grounded) {
      this.has_air_jumped = false;
    }
    else {
      this.wall_sliding = false;
    }
  }

  public void setWallSliding(bool val, Vector2 side) {
    this.wall_sliding = !grounded && val;
    this.wall_side = side;

    if (this.wall_sliding) {
      has_air_jumped = false;
    }
  }

  public void OnFeetTriggerEnter(Collider2D coll) {
    setGrounded(true);
  }
  public void OnFeetTriggerStay(Collider2D coll) {
    OnFeetTriggerEnter(coll);
  }
  public void OnFeetTriggerExit(Collider2D coll) {
    setGrounded(false);
  }
  
  public void OnSideTriggerEnter(Collider2D coll) {
    if (coll.GetContacts(contacts) > 0) {
      float dir_x = (contacts[0].point.x - transform.position.x);
      setWallSliding(true, (dir_x > 0) ? Vector2.right : Vector2.left);
    }
  }
  public void OnSideTriggerStay(Collider2D coll) {
    OnSideTriggerEnter(coll);
  }
  public void OnSideTriggerExit(Collider2D coll) {
    setWallSliding(false, Vector2.zero);
  }

  public void OnHeadTriggerEnter(Collider2D coll) {
    float gravity = (Physics2D.gravity * gravity_coefficient).y;
    if (velocity.y > -gravity) {
      velocity.y = -gravity;
    }
  }
  public void OnHeadTriggerStay(Collider2D coll) {
    OnHeadTriggerEnter(coll);
  }

}
