using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
private Animator anim;

void Setup(){
   anim=GetComponentInChildren<Animator>();
}
   void Update () 
 {
    int y = Random.Range(0, 2);
    if(y==1){
      anim.SetFloat("Horizontal", 2f);
    }
    else if(y==2){
      anim.SetFloat("Horizontal", -2f);
    }
 
  }
} 
