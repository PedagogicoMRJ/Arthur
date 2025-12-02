using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator chestAnim;
    public LayerMask playerLayer;
    public float interactRadious;
    bool onRadious = true;
    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Interact();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && onRadious)
        {
            chestAnim.SetBool("Open", true);
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadious, playerLayer);
        if(hit != null )
        {
            onRadious = true;
        }
        else
        {
            onRadious=false;
        }
    }
    private void OnDrawGizmosSelected()
    {
       Gizmos.DrawWireSphere(transform.position, interactRadious); 
    }
}
