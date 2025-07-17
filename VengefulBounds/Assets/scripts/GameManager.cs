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
    public bool spawnents = false;
    public bool gameBegan = false;

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
        spawnents = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.G)) ;
            {
                PlayIntroductionSlides();
            }
            gameBegan = false;
        }
        if (LoadingScreen)
        {
            LoadScr();
            
        }
        if(StartGame)
        {
            StartG();
            
        }

        
    }

    private void LoadScr()
    {
        LoadingScreenAnim.SetActive(true);
        SpawnEntities();
        StartCoroutine(BeginGame());
    }
    private void PlayIntroductionSlides()
    {
        MainMenu = false;
        Intro = true;
        spawnents= false;

        for (int i = 0; i < IntroScenes.Count-1; i++)
        {
            print("Reached");
            try
            {
                IntroScenes[i - 1].SetActive(false);
            }
            catch (System.Exception)
            {

                print("exception");
            }
            print("Error");
            IntroScenes[i].SetActive(true);



        }
        LoadingScreen = true;
    }
    private IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(5);
        StartGame = true;
    }
    private void SpawnEntities()
    {
        spawnents = true;
    }
    private void StartG()
    {
        LoadingScreenAnim.SetActive(false);
        UI.SetActive(true);
        SpawnBox.SetActive(false);
        gameBegan = true;
    }
}
    

