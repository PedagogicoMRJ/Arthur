using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{  
    public float speed = 5;
    Vector2 movement;
    Rigidbody2D bodyRig;
    void Start()
    {
        bodyRig = GetComponent<Rigidbody2D>();
    }
    void update()
    {
        Movement();
    }
    public void SetInputVector(Vector2 inputVector)
    {
        movement.x = inputVector.x;
        movement.y = inputVector.y;
    }
    void Movement()
    {
        if(movement.x != 0 && movement.y != 0)
        {
            bodyRig.velocity = new Vector2 (movement.x, movement.y) * speed * 0.7f;
        }
        else
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * speed;
        }
    }
    
}
