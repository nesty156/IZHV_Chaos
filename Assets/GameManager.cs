using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public static event Action<GameState> OnGameStateChanged;

     private void Awake()
    {
        Instance = this;
    }
     
     void Start()
     {
        UpdateGameState(GameState.GameMenu);
     }

    public static void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GameMenu:
                break;
            case GameState.GameSettings:
                break;
            case GameState.Game:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (State == GameState.GameSettings)
            {
                UpdateGameState(GameState.Game);
            }
            else
            {
                UpdateGameState(GameState.GameSettings);
            }
        }
    }

    public enum GameState
    {
        GameMenu,
        GameSettings,
        Game,
        Victory,
        Lose
    }
}
