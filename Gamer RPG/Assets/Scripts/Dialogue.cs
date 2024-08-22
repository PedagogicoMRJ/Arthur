using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
     public string nameText;
     public string[] speechText;
     private DialogueManager dm;
     public LayerMask playerLayer;
     public float interactRadious;
     bool onRadious = true;
     void Start()
     {
        dm = GetComponent<DialogueManager>();
     }
    private void FixedUpdate()                                                      //ESTAVA PROGRAMADO COMO UPDATE
    {
            Interact();
    }
    private void Update()
     {
        if (Input.GetKeyDown(KeyCode.E) && onRadious)
        {
            dm.Speech(nameText, speechText);
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
     private void OnDrawGizmosSelected()                                                          //Estava OndrawGizmoSelected o que fazia a função não ser lida
     {
       Gizmos.DrawWireSphere(transform.position, interactRadious);
     }
 
}
