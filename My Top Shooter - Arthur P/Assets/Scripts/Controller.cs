using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float reloadTime;
    Bullet bulletParameters;
    public float velocity = 5;
    Vector2 playerPosition;
    Vector2 aimDirection;
    Vector2 movement;
    Vector2 aim;
    bool isAiming;
    Rigidbody2D bodyRig;
    Animator anim;
    public GameObject crossHair;
    void Start()
    {
      reloadTime = 2.0f;
      bulletParameters = GetComponentInChildren<Bullet>();
      bodyRig = GetComponent<Rigidbody2D>();
      anim = GetComponentInChildren<Animator>();
      crossHair.SetActive(false);
      Cursor.visible = false;
    }
    void Update()
    {
        reloadTime += Time.deltaTime;
        playerPosition = transform.position;
        if(isAiming)
        {
            Aiming();
        }
        else
        {
        Movement();
        }
    }
    void Movement()
    {
        crossHair.SetActive(false);
        if (movement.x != 0 && movement.y != 0)
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * velocity * 0.7f;
        }
        else
        {
            bodyRig.velocity = new Vector2(movement.x, movement.y) * velocity;
        }
        anim.SetBool("Aim", false);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);
    }
    public void SetInputVector(Vector2 inputVector, Vector2 mouseVector, bool aiming)
    {
        movement.x = inputVector.x;
        movement.y = inputVector.y;
        aim = mouseVector;
        isAiming = aiming;
    }
    public void Aiming()
    {
        aimDirection = aim - playerPosition;
        aimDirection.Normalize();
        crossHair.SetActive(true);
        bodyRig.velocity = Vector2.zero;
        anim.SetBool("Aim", true);
        anim.SetFloat("AimHorizontal", aimDirection.x);
        anim.SetFloat("AimVertical", aimDirection.y);
        crossHair.transform.position = aim;
        if (Input.GetMouseButtonDown(0) && reloadTime >= 3)
        {
            reloadTime = 0.0f;
            bulletParameters.fireBullet(aimDirection, aim);
        }
    }
}