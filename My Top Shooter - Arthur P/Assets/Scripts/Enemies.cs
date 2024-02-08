using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Timeline.Actions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
     public int tipeEnemyFirst;
    public int tipeEnemyFinal;
    public int numberEnemy;
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public EnemyHandler[] prefabs;
    public GameObject[] spawnEnemies;

    private void Start()
    {
        enemiesDied = false;

         for (int j = tipeEnemyFirst; j < tipeEnemyFinal; j++)
        {
            for (int i = 0; i < numberEnemy; i++)
            {
                // Instance GameObject that recives enemy spawn point
                GameObject spawnPoint = GetRandomSpawnPoint();
                // Local object of type Enemy responsible for instantiating the prefabs
                EnemyHandler enemy = Instantiate(this.prefabs[j], this.transform);
                // Active killed action when EnemyKilled is called
                enemy.killed += EnemyKilled;
                // Position the enemy with position parameters
                enemy.transform.localPosition = spawnPoint.transform.position;
            }
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == (tipeEnemyFinal-tipeEnemyFirst)*numberEnemy)
        {
            enemiesDied=true;
        }
        teleport.IsActive(enemiesDied);
    }
    
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
}
