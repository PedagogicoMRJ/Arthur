using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BattleStage { WATING, START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public BattleStage stage;
    BattleHUD battleHUD;
    EnemyHandler enemyUnit;
    PlayerHandler playerUnit;
    public bool isFighting;
    // Start is called before the first frame update
    void Awake()
    {
        isFighting = false;
        stage = BattleStage.WATING;
        battleHUD = GameObject.FindGameObjectWithTag("BattleHUD").GetComponent<BattleHUD>();
        playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (!isFighting)
        {
            isFighting = playerUnit.isFighting;
            if (isFighting)
            {
                StartFighting();
            }

        }
    }
    public void StartFighting()
    {
        Debug.Log("The fight began");
        stage = BattleStage.START;
        battleHUD.gameObject.SetActive(true);
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        enemyUnit = GameObject.FindGameObjectWithTag("isFighting").GetComponent<EnemyHandler>();
        playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
        battleHUD.SetHUD(enemyUnit, playerUnit);
        yield return new WaitForSeconds(1f);
        stage = BattleStage.PLAYERTURN;
        PlayerTurn();
    }
    void PlayerTurn()
    {
        Debug.Log("Choose an action");
    }
    public void AttackButton()
    {
        if (stage != BattleStage.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }
    public void HealButton()
    {
        if (stage != BattleStage.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }
    IEnumerator PlayerAttack()
    {
        Debug.Log("The Player attack the Enemy");
        bool isDead = enemyUnit.TakeDamage(playerUnit.playerDamage);
        yield return new WaitForSeconds(1f);
        battleHUD.SetHP(enemyUnit.enemyHealth, playerUnit.playerHealth);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            stage = BattleStage.WON;
            StartCoroutine(EndBattle());
        }
        else
        {
            Debug.Log("Enemy Turn");
            stage = BattleStage.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator PlayerHeal()
    {
        Debug.Log("The Player heal herself");
        playerUnit.Heal(5);
        yield return new WaitForSeconds(1f);
        battleHUD.SetHP(enemyUnit.enemyHealth, playerUnit.playerHealth);
        yield return new WaitForSeconds(1f);
        Debug.Log("Enemy Turn");
        stage = BattleStage.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator EnemyTurn()
    {
        Debug.Log("The Enemy attack the Player");
        bool isDead = playerUnit.TakeDamage(enemyUnit.enemyDamage);
        yield return new WaitForSeconds(1f);
        battleHUD.SetHP(enemyUnit.enemyHealth, playerUnit.playerHealth);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            Debug.Log("You died");
            stage = BattleStage.LOST;
            StartCoroutine(EndBattle());
        }
        else
        {
            Debug.Log("Player Turn");
            stage = BattleStage.PLAYERTURN;
            PlayerTurn();
        }
    }
    IEnumerator EndBattle()
    {
        if(stage == BattleStage.WON)
        {
            Debug.Log("You Won the Battle");
            playerUnit.isFighting = false;
            isFighting = false;
        }
        else if(stage == BattleStage.LOST)
        {
            Debug.Log("You Lost the Battle");
            playerUnit.isFighting = false;
            isFighting = false;
        }
        yield return new WaitForSeconds(1f);
        stage = BattleStage.WATING;
        battleHUD.gameObject.SetActive(false);
    }
}
