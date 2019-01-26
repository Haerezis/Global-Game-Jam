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

  [Header("Animation")]
  public Animator animator;

  [Header("Particule Dash")]
  public float bullet_time_coeficient = 0.01f;
  public float bullet_time_timeout = 4.0f;
  public float dash_speed = 40.0f;

  // state:
  protected Vector2 velocity;

  protected bool grounded = false;
  protected bool wall_sliding = false;
  protected Vector2 wall_side;
  protected bool has_air_jumped = false;
  protected bool facing_right = true;

  protected bool bullet_time_active = false;
  protected GameObject dash_particule = null;

  // misc:
  protected Rigidbody2D rgbd;
  protected ContactPoint2D[] contacts = new ContactPoint2D[10];
  protected SpriteRenderer sprite_renderer;

  void Awake() {
    this.rgbd = this.gameObject.GetComponent<Rigidbody2D>();
    this.sprite_renderer = this.gameObject.GetComponent<SpriteRenderer>();
  }
  
  void Update()
  {
    ComputeVelocity();
  }

  protected void ComputeVelocity()
  {
    if (Input.GetButtonDown("Fire1") && this.dash_particule != null) {
      this.beginParticuleDash();
      //this.endParticuleDash((Vector2.right + Vector2.up).normalized);
    }

    float x_movement = 0.0f;
    
    if (!this.bullet_time_active) {
      x_movement = Input.GetAxis ("Horizontal");

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
    }

    // gravity:
    if (!grounded) {
      velocity += Physics2D.gravity * gravity_coefficient * Time.timeScale;
    }
    else if (velocity.y < 0) {
      velocity.y = 0.0f;
    }

    //Handle max fall speed.
    if (velocity.y < -max_fall_speed) {
      velocity.y = -max_fall_speed;
    }

    if ((x_movement > 0.05f || velocity.x > 1) && !facing_right) {
      flip();
    }
    else if ((x_movement < -0.05f || velocity.x < -1) && facing_right) {
      flip();
    }

    animate();

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

  // Kill the player (make it invisible and non interactible) => waiting to be respawn.
  public void kill() {
    // Death animation
    this.rgbd.velocity = Vector2.zero;
    this.rgbd.isKinematic = true;
    this.sprite_renderer.enabled = false;
  }

  // Spawn the player at the given position.
  public void spawn(Vector2 position) {
    this.grounded = false;
    this.wall_sliding = false;
    this.has_air_jumped = false;
    this.facing_right = true;

    this.rgbd.isKinematic = false;
    this.rgbd.velocity = Vector2.zero;
    this.rgbd.position = position;
    this.sprite_renderer.enabled = true;
  }

  // Set animator parameters to display the right animation
  protected void animate() {
    if (grounded) {
      animator.SetBool("jumping", false);
      animator.SetBool("falling", false);

      if(Mathf.Abs(velocity.x) > 0.1f) {
        animator.SetBool("walking", true);
      }
      else {
        animator.SetBool("walking", false);
      }
    }
    else {
      animator.SetBool("walking", false);

      if(velocity.y > 0.1f) {
        animator.SetBool("jumping", true);
        animator.SetBool("falling", false);
      }
      else if (velocity.y < -0.1f) {
        animator.SetBool("jumping", false);
        animator.SetBool("falling", true);
      }
    }

  }

  // Flip the localScale of the player (to reuse same sprite when going left & right).
  protected void flip() {
    // Switch the way the player is labelled as facing.
    facing_right = !facing_right;

    // Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
    transform.localScale = theScale;
  }

  public void setDashParticule(GameObject particule) {
    if (this.dash_particule != null) {
      if (this.dash_particule.GetInstanceID() != particule.GetInstanceID()) {
        return;
      }

      float distance = Vector2.Distance(particule.transform.position, this.transform.position);
      float current_distance = Vector2.Distance(this.dash_particule.transform.position, this.transform.position);

      if (distance < current_distance) {
        this.dash_particule = particule;
      }
    }
    else {
      this.dash_particule = particule;
    }
  }

  public void unsetDashParticule(GameObject particule) {
    if ((particule == this.dash_particule) && !this.bullet_time_active) {
      this.dash_particule = null;
    }
  }

  public void beginParticuleDash() {
    this.bullet_time_active = true;

    Time.timeScale = bullet_time_coeficient;
    Time.fixedDeltaTime = 0.02f * Time.timeScale;

    this.dash_particule.GetComponent<ArrowController>().activateControls(this, this.bullet_time_timeout);
  }

  public void endParticuleDash(Vector2 direction_normalized) {
    this.bullet_time_active = false;

    Time.timeScale = 1.0f;
    Time.fixedDeltaTime = 0.02f;

    this.rgbd.position = this.dash_particule.transform.position;
    this.rgbd.velocity = direction_normalized * dash_speed;
  }

  /////////////////////////////////////////////////////
  /// Collision/Trigger methods
  ////////////////////////////////////////////////////

  public void OnFeetTriggerEnter(Collider2D coll) {
    if (!ignoreCollider2D(coll)) {
      setGrounded(true);
    }
  }
  public void OnFeetTriggerStay(Collider2D coll) {
    OnFeetTriggerEnter(coll);
  }
  public void OnFeetTriggerExit(Collider2D coll) {
    setGrounded(false);
  }
  
  public void OnSideTriggerEnter(Collider2D coll) {
    if (!ignoreCollider2D(coll)) {
      if (coll.GetContacts(contacts) > 0) {
        float dir_x = (contacts[0].point.x - transform.position.x);
        setWallSliding(true, (dir_x > 0) ? Vector2.right : Vector2.left);
      }
    }
  }
  public void OnSideTriggerStay(Collider2D coll) {
    OnSideTriggerEnter(coll);
  }
  public void OnSideTriggerExit(Collider2D coll) {
    setWallSliding(false, Vector2.zero);
  }

  public void OnHeadTriggerEnter(Collider2D coll) {
    if (!ignoreCollider2D(coll)) {
      float gravity = (Physics2D.gravity * gravity_coefficient).y;
      if (velocity.y > -gravity) {
        velocity.y = -gravity;
      }
    }
  }
  public void OnHeadTriggerStay(Collider2D coll) {
    OnHeadTriggerEnter(coll);
  }

  public bool ignoreCollider2D(Collider2D c) {
    return (c.gameObject.tag == "UI" || c.gameObject.tag == "Particule");
  }

}
