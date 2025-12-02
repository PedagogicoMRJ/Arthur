using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    public string playerName;
    public int playerLevel;
    public int playerDamage;
    public int playerHeal;
    public int playerHealth;
    public int playerMaxHealth;
    public int playerArmor;
    public float playerExperience;
    public float playerMaxExperience;
    Vector2 inputVector = Vector2.zero;
    Controller playerController;

    public bool isFighting;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        playerController.SetInputVector(inputVector);
    }
    public bool TakeDamage(int damage)
    {
        Debug.Log("The player take damage");
        /*damage -= playerArmor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue)*/
        playerHealth -= damage;
        if (playerHealth <= 0)
            return true;
        else return false;
    }
    public void Heal(int amount)
    {
        Debug.Log("The Player increase her health");
        playerHealth += amount;
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }
    /* public void GainExperience(int experience)
    {
        playerExperience += experience;
        if(playerExperience >= playerMaxExperience)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        playerLevel++;
        playerMaxHealth += 10;
        playerHealth = playerMaxHealth;
        playerArmor++;
        playerDamage += 5;
        playerHeal += 5;
        playerExperience = playerExperience - playerMaxExperience;
        playerMaxExperience = playerMaxExperience * 1.5f;
    }*/
}
