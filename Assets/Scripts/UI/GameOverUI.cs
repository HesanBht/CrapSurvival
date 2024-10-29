using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button retryButton;

    [SerializeField] GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onPlayerDeath += GameOverLogic;

        mainMenuButton.onClick.AddListener(LoadMainMenu);
        retryButton.onClick.AddListener(RetryGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerHealth.onPlayerDeath -= GameOverLogic;
        
    }
    public void GameOverLogic()
    {
        TimeManager.instance.PauseGame();
        gameOverPanel.SetActive(true);
    }


    void LoadMainMenu()
    {
        TimeManager.instance.ResumeGame();
        SceneManager.LoadScene(0);
    }
    void RetryGame()
    {
        TimeManager.instance.ResumeGame();
        SceneManager.LoadScene(1);
    }

}
