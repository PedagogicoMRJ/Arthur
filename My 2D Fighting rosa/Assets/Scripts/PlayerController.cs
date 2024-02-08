using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
   public bool isPlayer1;
   bool isAttack = false;
    bool isKnockback = false;
    string attack = "None";
    public float speed;
    private Animator anim;
    private Rigidbody2D rig;
    float move;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
       if (isKnockback)
       {
        anim.SetBool("Knockback", false);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            isKnockback = false;
        }
       }
       if (isAttack)
     {
       if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
       {
        isAttack = false;
       }
     }
    }
    void Update()
    {
        if (!isAttack && !isKnockback)
        {
        Movement();
        Attack();
        }
        if(!isAttack)
        {
            Movement();
            Attack();
        }
    }
    void Movement()
    {
        if (isPlayer1)
        {
            move = Input.GetAxis("Horizontal1");
        }
        else
        {
            move = Input.GetAxis("Horizontal2");
        }
        move = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(move * speed, 0.0f);
        anim.SetFloat("Walk", move);
    }
    void Attack()
    {
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                attack = "LightPunch";
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                attack = "HeavyPunch";
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                attack = "LightKick";
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                attack = "HeavyKick";
            }
            else
            {
                attack = "None";
            }
        }
        else{
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                attack = "LightPunch";
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                attack = "HeavyPunch";
            }
            else if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                attack = "LightKick";
            }
            else if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                attack = "HeavyKick";
            }   
            else
            {
                attack = "None";
            }
        }
        if(attack != "None")
        {
            move = 0;
            rig.velocity = new Vector2(move * speed, 0.0f);
            anim.SetFloat("Walk", move);
            anim.SetTrigger(attack);
            isAttack = true;
        }
    }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        move = 0;
        rig.velocity = new Vector2(0.0f, 0.0f);
        anim.SetFloat("Walk", move);
        if (collision.gameObject.layer == 3)
        {
            anim.SetBool("Knockback", true);
            if (isPlayer1)
            {
                rig.velocity = new Vector2(speed * (-1), 0.0f);
            }
        }
    }
}