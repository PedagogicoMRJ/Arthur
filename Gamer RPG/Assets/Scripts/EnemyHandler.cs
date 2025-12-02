using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour, IInteractable
{
    //public bool isBoss;
    public bool isEnemyDead;
    //public bool isArmored = false;
    public string enemyName;
    public int enemyLevel;
    //public int enemyHeal;
    public int enemyHealth;
    public int enemyMaxHealth;
    public int enemyDamage;
    //public int enemyArmor;
    private Animator enemyAnim;
    //public int enemyExperience;
    void Start()
    {
        isEnemyDead = false;
        enemyAnim = GetComponentInChildren<Animator>();
    }
    public bool TakeDamage(int damage)
    {
        Debug.Log("The enemy take damage");
        //damage -= enemyArmor;
        enemyHealth -= damage;
        /*if (isArmored)
        {
            enemyArmor -= 10;
            isArmored = false;
            Debug.Log("The Armor was Broken");
        }*/
        if (enemyHealth <= 0)
        {
            EnemyDie();
            return true;
        }
        else
            return false;
    } 
    void EnemyDie()
    {
        Debug.Log("The Enemy died");
        Destroy (gameObject, 2f);
    }
    public void Interact()
    {
        Debug.Log("The Enemy is read to fight");
        gameObject.tag = "isFighting";
    }
    /*public void Heal()
    {
        Debug.Log("The Enemy increase her health");
        enemyHealth += enemyHeal;
        if (enemyHealth > enemyMaxHealth)
           enemyHealth = enemyMaxHealth;
    }
    public void Armor()
    {
        if (!isArmored)
        {
            enemyArmor += 10;
            isArmored = true;
            Debug.Log("The Enemy increase her Armor");
        }
        else
        {
            Heal();
        }
    }*/
}
