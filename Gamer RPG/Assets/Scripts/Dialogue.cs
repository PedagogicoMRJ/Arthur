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
    dm = FindAnyObjectByType<DialogueManager>();
 }
private void FixedUpdate()
{
   if (Input.GetKeyDown(KeyCode.E) && onRadious)
   {
      dm.Speech(nameText, speechText);
   }
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
 private void OndrawGizmoSelected()
 {
   Gizmos.DrawWireSphere(transform.position, interactRadious);
 }
 
}
