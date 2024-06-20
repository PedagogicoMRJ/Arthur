using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialog;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI speechText;
    public float typingSpeed;
    private string[] sentences;
    private int index;
    public void Start(){
        
    }
    public void Speech(string nametxt, string[] speechtxt)
    {
        dialog.SetActive(true);
        nameText.text = nametxt;
        sentences = speechtxt;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
          speechText.text += letter;
          yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "Iae Bro";
                StartCoroutine(TypeSentence());           
            }
            else
            {
                speechText.text = "Como c tá";
                index = 0;
                dialog.SetActive(false);
            }
        }
    }
    public void Destrui(){
        dialog.SetActive(false);
        Destroy(this.dialog);
    }
}
