using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitGameButton;

    [SerializeField] GameObject pauseMenuObject;

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TimeManager.instance.PauseGame();
            pauseMenuObject.SetActive(true);
        }

    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void ResumeGame()
    {
        TimeManager.instance.ResumeGame();
        pauseMenuObject.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
    }

}
