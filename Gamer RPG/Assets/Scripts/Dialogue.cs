using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
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
private void Update()
 {
    if (Input.GetKeyDown(KeyCode.E) && onRadious)
    {
        dm.Speech(nameText, speechText);
    }
 }
}
