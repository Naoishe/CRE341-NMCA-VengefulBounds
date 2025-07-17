using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public static int GemCountReset = 0;
    public GameObject gemPrefab;
    public int GemSpawned = 0;

    private bool destroyAll = false;

    public GameManager gameManager; 
    private bool enablegen = false;

    private void Update()
    {
        destroyAll = gameManager.gameBegan;
        if (gameManager.spawnents)
        {
            enablegen= true;
        }
        if (enablegen)
        {
            for(int i=0; i<20; i++)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(25, 250), 20, Random.Range(25, 250));
                Instantiate(gemPrefab, randomSpawnPosition, Quaternion.identity);
                GemSpawned=GemSpawned+1;
            }
            
        }
    }

}
