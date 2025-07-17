using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    [SerializeField] private AudioSource MenuMusic;
    [SerializeField] private AudioSource PlayMusic;
    public GameManager gm;

    void Start()
    {
       MenuMusic.Play();
       PlayMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameBegan)
        {
            InGameMusic();
        }
        else
        {
            InMenuMusic();
        }
    }

    private void InGameMusic()
    {
        MenuMusic.Stop();
        PlayMusic.Play();
    }
    private void InMenuMusic()
    {
        PlayMusic.Stop();
        MenuMusic.Play();
    }
}
