using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
  public GameObject arrow;

  protected bool in_progress = false;
  protected Player player = null;
  protected float timeout_timestamp = 0.0f;

  protected Vector2 arrow_direction = Vector2.up;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if(in_progress) {
      if ((Input.GetButtonDown("Fire1") || ( Time.fixedUnscaledTime >= this.timeout_timestamp ))) {
        this.finishParticuleDash();
      }
      else {
        this.rotateArrow();
      }
    }
  }

  void rotateArrow() {
    Vector2 input = new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
    if ( input.sqrMagnitude < 1.0f ) {
      input = this.arrow_direction;
    }

    float angle = (Vector2.SignedAngle(Vector2.right, input) - 43.0f);
    angle = Mathf.Sign(transform.localScale.x) < 0 ? angle - 90.0f : angle;
    this.arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    this.arrow_direction = input.normalized;
  }

  void OnTriggerEnter2D(Collider2D c) {
    this.OnTriggerStay2D(c);
  }

  void OnTriggerStay2D(Collider2D c) {
    if (c.gameObject.tag == "Player") {
      Player player = c.gameObject.GetComponent<Player>();
      player.setDashParticule(this.gameObject);
    }
  }

  void OnTriggerExit2D(Collider2D c) {
    if (c.gameObject.tag == "Player") {
      Player player = c.gameObject.GetComponent<Player>();
      player.unsetDashParticule(this.gameObject);
    }
  }

  public void activateControls(Player player, float timeout) {
    this.player = player;
    this.timeout_timestamp = Time.fixedUnscaledTime + timeout;
    this.arrow_direction = (this.transform.position - player.gameObject.transform.position).normalized;
    this.arrow.GetComponent<SpriteRenderer>().enabled = true;
    this.in_progress = true;
    this.rotateArrow();
  }

  public void finishParticuleDash() {
    this.in_progress = false;
    this.arrow.GetComponent<SpriteRenderer>().enabled = false;
    this.player.endParticuleDash(this.arrow_direction);
  }
}
