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

    [SerializeField] private TextMeshProUGUI stateText;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.GameMenu)
        {
            LoadMenu();
        }
        else if (state == GameManager.GameState.GameSettings)
        {
            Pause();
        }
        else
        {
            Resume();
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
        Time.timeScale = 1;
    }
    
    void Pause()
    {
        pausedMenuPanel.SetActive(true);
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
        GameManager.UpdateGameState(GameManager.GameState.Game);
        Time.timeScale = 1;
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
