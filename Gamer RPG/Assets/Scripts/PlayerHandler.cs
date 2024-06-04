using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
  public bool isEnemyDead;
  public string playerName;
  public int playerLevel;
  public int playerHeal;
  public int playerMaxHealth;
  public int playerArmor;
  public float playerExperience;
  public float playerMaxExperience;
  public int playerHealth;
  public int playerDamage;
  private Animator enemyAnim;
  public bool isFighting;
  Vector2 inputVector = Vector2.zero;
  Controller playerController;
  void Start()
  {
    playerController = GetComponent<Controller>();
  }
  void Update()
  {
    inputVector.x = Input.GetAxis("Horizontal");
    inputVector.y = Input.GetAxis("Vertical");
    playerController.SetInputVector(inputVector);
  }
  public bool TakeDamage(int damage)
  {
    Debug.Log("The Player take damage");
    damage -= playerArmor;
    damage = Mathf.Clamp(damage, 0, int.MaxValue);
    playerHealth -= damage;
    if (playerHealth <=0)
     return true;
    else
     return false;
  }
  public void Heal (int amount)
  {
    Debug.Log("The Player increase her health");
    playerHealth += amount;
    if (playerHealth > playerMaxHealth)
      playerHealth = playerMaxHealth;
  }
  public void GainExperience(int experience)
  {
     playerExperience += experience;
    if (playerExperience >= playerMaxExperience)
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
    playerMaxExperience = playerMaxExperience*1.5f;
  }
}
