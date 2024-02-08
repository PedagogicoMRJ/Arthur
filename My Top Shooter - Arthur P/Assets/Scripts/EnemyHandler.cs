using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;

public class EnemyHandler : MonoBehaviour
{
    Transform playerPos;
    Bullet bulletParameters;
    Animator anim;
    private Vector2 randomNum;
    private Vector2 randomPos;
    public System.Action killed;
    public bool hasWalkAnim;
    float walkTime;
    public bool hasRandomWalk;
    public float enemySpeed;
    Rigidbody2D enemyRig;
    Vector2 targetDir;
    void Start()
    {
        bulletParameters = GetComponentInChildren<Bullet>();
        randomNum = new Vector2((int)Mathf.Round(Random.Range(-1.0f, 1.0f)), (int)Mathf.Round(Random.Range(-1.0f, 1.0f)));
        anim = GetComponentInChildren<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randomPos = new Vector2(this.transform.position.x + randomNum.x, this.transform.position.y + randomNum.y);
        enemyRig = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        walkTime += Time.deltaTime;
        targetDir = playerPos.position - this.transform.position;
        targetDir.y += 0.5f;
        targetDir.Normalize();
        if (hasWalkAnim)
        {
             if (hasRandomWalk && (walkTime >= 2))
             {
                Fire();
                walkTime = 0.0f;
                randomNum = new Vector2((int)Mathf.Round(Random.Range(-1.0f, 1.0f)), (int)Mathf.Round(Random.Range(-1.0f, 1.0f)));
                randomPos = new Vector2(this.transform.position.x + randomNum.x, this.transform.position.y + randomNum.y);
             }
            Walk();
        }
        else
        {
            Follow();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
    void Follow()
    {
        if(enemyRig.velocity.magnitude <= 5.0f)
        {
            enemyRig.AddForce(targetDir * enemySpeed);
        }
    }
    void Walk()
    {
     if (hasRandomWalk)
     {
      targetDir = new Vector2(randomPos.x - this.transform.position.x, randomPos.y - this.transform.position.y);
      targetDir.Normalize();
      enemyRig.velocity = Vector2.zero;
      enemyRig.velocity = new Vector2(targetDir.x, targetDir.y) * enemySpeed;
     }
     anim.SetFloat("Horizontal", targetDir.x);
     anim.SetFloat("Vertical", targetDir.y);
     anim.SetFloat("Magnitude", targetDir.magnitude);
    }
     void Fire()
     {
     bulletParameters.fireBullet(targetDir, playerPos.position);
     }
}
