using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
public bool isFighting;

private Animator anim;
 public int enemyDamage;

void Start()
{
  anim = GetComponentInChildren<Animator>();
}
 public void Attack()
{
    int i=Random.Range(0,5);
    if(i==1)
    {
        anim.SetBool("Attack", true);
        //bodyRig.velocity = new Vector2(1f, 1f) * speed *1f;
    }
}
}