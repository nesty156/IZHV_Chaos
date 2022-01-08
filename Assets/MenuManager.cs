using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameMenuPanel;
    [SerializeField] private GameObject pausedMenuPanel;
    [SerializeField] private GameObject VictoryScreen;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject InfoScreen;
    public AudioSource victoryMusic;

    [SerializeField] private TextMeshProUGUI stateText;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        InfoScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        switch(state) 
        {
            case GameManager.GameState.GameMenu:
                LoadMenu();
                break;
            case GameManager.GameState.GameSettings:
                Pause();
                break;
            case GameManager.GameState.Victory:
                Victory();
                break;
            case GameManager.GameState.Lose:
                Lose();
                break;
            default:
                Resume();
                break;
        }
    }

// Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Resume()
    {
        pausedMenuPanel.SetActive(false);
        InfoScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        LoseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    
    void Pause()
    {
        pausedMenuPanel.SetActive(true);
        InfoScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        LoseScreen.SetActive(false);
        Time.timeScale = 0;
    }
    
    void Victory()
    {
        VictoryScreen.SetActive(true);
        victoryMusic.Play();
        Time.timeScale = 0;
    }
    
    void Lose()
    {
        LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void LoadMenu()
    {
        pausedMenuPanel.SetActive(false);
        gameMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void StartGame()
    {
        gameMenuPanel.SetActive(false);
        pausedMenuPanel.SetActive(false);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Game);
        Time.timeScale = 1;
    }
    
    public void Info()
    {
        gameMenuPanel.SetActive(false);
        InfoScreen.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    
    public void QuitGame()
    {
    #if UNITY_EDITOR
        // Quitting in Unity Editor: 
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER || UNITY_WEBGL
        Application.ExternalEval("document.location.reload(true)");
    #else // !UNITY_WEBPLAYER
        Application.Quit();
    #endif
    }
}
