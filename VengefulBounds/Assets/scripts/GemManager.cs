using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    private int CollectedGems = 0;
    private bool GameOver = false;
    private bool Victory=false;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectedGems = CollectedGems + 1;
        }
    }

    private void Update()
    {
        if(GameOver)
        {
            CollectedGems = GemSpawner.GemCountReset;
        }
        if(CollectedGems >= 20) 
        {
            Victory= true;
        }
        if(CollectedGems<20) 
        {
            GameOver = false;
            Victory= false;
        }
    }
}
