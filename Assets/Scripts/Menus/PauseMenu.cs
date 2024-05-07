using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public TextHelper 
        time,
        points;

    public InputAction pauseAction;

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    private void Update()
    {
        if (pauseAction.triggered)
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if(isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        time.DisableTexts();
        points.DisableTexts();
        isPaused = false;
    }

    public void Pause()
    {
        playerInput.SwitchCurrentActionMap("UI");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        time.EnableTexts();
        points.EnableTexts();
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

}
