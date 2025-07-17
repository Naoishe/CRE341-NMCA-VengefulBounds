using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int EnemyCountReset = 0;
    public GameObject enemyPrefab;
    public int enemiesSpawned = 0;

    private bool destroyAll = false;

    public GameManager gameManager;
    private bool enablegen = false;
    private bool roundgenerated = false;


    private void Update()
    {
        destroyAll = gameManager.gameBegan;
        if (gameManager.spawnents)
        {
            enablegen = true;
        }
        if (enablegen)
        {
            if(roundgenerated=false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(25, 250), 20, Random.Range(25, 250));
                    Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
                    enemiesSpawned = enemiesSpawned + 1;
                }
                roundgenerated= true;
            }
            

        }
    }
}
