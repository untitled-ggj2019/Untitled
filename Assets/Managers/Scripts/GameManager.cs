﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    [Header("Manager Prefabs")]
    public SoundManager soundManager;
    public ScoreManager scoreManager;

    [Header("Game Loop Script")]
    public GameLoopScript gameLoop;

    // Delegates
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        }
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
        //Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (SoundManager.instance == null)
        {
            //Instantiate SoundManager prefab
            Instantiate(soundManager);
        }

        if (ScoreManager.instance == null)
        {
            //Instantiate SoundManager prefab
            Instantiate(scoreManager);
        }

        //Cache components into the variables
        gameLoop = GetComponent<GameLoopScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
