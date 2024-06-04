using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{  
    public bool isStartingAFight;
    public float speed = 5;
    Vector2 movement;
    Animator anim;
    Rigidbody2D bodyRig;
    public LayerMask interactLayer;
    public float interactRadious;
    void Start()
    {
        isStartingAFight = false;
        bodyRig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (isStartingAFight)
            {
                isStartingAFight = false;
            }
            InteractableObj();
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
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);
}
    private void OnDrawGizmoSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadious);
    }
    public void InteractableObj()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadious, interactLayer);
        if (hit != null)
        {
            IInteractable obj = hit.transform.GetComponent<IInteractable>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (obj == null) return;
                if (hit.CompareTag("Enemy"))
                {
                    Debug.Log("Você encontrou um inimigo");
                    isStartingAFight = true;
                }
                obj.Interact();
            }
        }
    }
}
