using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator chestAnim;
    public LayerMask playerLayer;
    public float interactRadious;
    bool onRadious = true;
    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }
     private void FixedUpdate()
 {
    Interact();
 }
 private void Update()
 {
    if (Input.GetKeyDown(KeyCode.E) && onRadious)
    {
        chestAnim.SetBool("Open", true);
    }
 }
 public void Interact()
 {
    Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadious, playerLayer);
    if(hit != null)
    {
        onRadious = true;
    }
    else
    {
        onRadious = false;
    }
 }
 private void OnDrawGizmosSelected()                                                                        //estava OnDrawGizmosSelectted
    {
    Gizmos.DrawWireSphere(transform.position, interactRadious);
 }
}
