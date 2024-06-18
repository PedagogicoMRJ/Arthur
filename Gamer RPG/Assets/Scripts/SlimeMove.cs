using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
private Animator anim;
public float speed = 6;
    Rigidbody2D bodyRig;

Vector2 movement;
void Start()
{
  bodyRig = GetComponent<Rigidbody2D>();
  anim = GetComponentInChildren<Animator>();
}
void Update(){
  Movement();
}
void Movement()
{
  movement.x = Input.GetAxis("Horizontal");
  movement.y = Input.GetAxis("Vertical");
  if(movement.x != 0 && movement.y != 0)
        {
            bodyRig.velocity = new Vector2 (movement.x, movement.y) * speed * 0.7f;
        }
        else
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * speed;
        }
  anim.SetFloat("Horizontal", movement.y);
  anim.SetFloat("Vertical", movement.x);
  anim.SetFloat("Magnitude", movement.magnitude);
}
} 