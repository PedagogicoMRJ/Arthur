using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public bool enemiesDied;
    public Teleport teleport;
    public int enemiesKilled;
    public EnemyHandler[] prefabs;
    public GameObject[] spawnEnemies;

    private void Start()
    {
        enemiesDied = false;

        for (int i = 0; i < 4; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
            GameObject spawnPoint = GetRandomSpawnPoint();
            EnemyHandler enemie = Instantiate(this.prefabs[0], this.transform);
            enemie.killed += EnemyKilled;
            enemie.transform.localPosition = position;
        }
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == 4)
        {
            enemiesDied = true;
        }
        teleport.IsActive(enemiesDied);
    }
    
    GameObject GetRandomSpawnPoint()
    {
        return spawnEnemies[Random.Range(0, spawnEnemies.Length)];
    }
}
