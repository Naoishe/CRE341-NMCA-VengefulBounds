using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public bool GameOver = false;
    public bool Victory = false;
    public bool MainMenu = false;
    public bool StartGame = false;
    public bool LoadingScreen = false;
    public bool Intro = false;

    [SerializeField] GameObject MainMenuScreen;
    public List<GameObject> IntroScenes;
    [SerializeField] GameObject LoadingScreenAnim;
    [SerializeField] GameObject VictoryScreen;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject UI;

    private Vector3 PlayerSpawn = new Vector3(111,41,115);

    [SerializeField] GameObject SpawnBox;

    [SerializeField] GameObject Player;

    void Start()
    {
        MainMenuScreen.SetActive(true);
        MainMenu=true;
        SpawnBox.SetActive(true);
        Player.transform.position = PlayerSpawn;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.G)) ;
            { 
                MainMenu = false;
                Intro = true;
         
                for(int i=0; i<IntroScenes.Count; i++)
                {
                    try
                    {
                        IntroScenes[i - 1].SetActive(false);
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    try
                    {
                        IntroScenes[i].SetActive(true);
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    
                    
                }
                LoadingScreen = true;
            }
        }
        if (LoadingScreen)
        {
            LoadingScreenAnim.SetActive(true);
        }
        if(StartGame)
        {
            LoadingScreenAnim.SetActive(false);
            UI.SetActive(true);
            StartCoroutine(Begin());
            SpawnBox.SetActive(false);
            
        }

        
    }

    private IEnumerator Begin()
    {
        yield return new WaitForSeconds(10);
        StartGame=true;
    }
}
