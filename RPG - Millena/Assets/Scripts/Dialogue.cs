using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Dialogue : MonoBehaviour, IInteractable
{
    public string nameText;
    public string[] speechText;
    private DialogueManager dm;
    public LayerMask playerLayer;
    public float interactRadious;
    bool onRadious = true;
    // Start is called before the first frame update
    void Start()
    {
        dm = GetComponent<DialogueManager>();
    }
    private void FixedUpdate()
    {
        Interact();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onRadious)
        {
            dm.Speech(nameText, speechText);
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadious, playerLayer);
        if (hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadious);
    }
}