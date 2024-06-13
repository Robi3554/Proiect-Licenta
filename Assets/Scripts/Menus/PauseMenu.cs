using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InventoryManager inventoryManager;

    [SerializeField]
    private PlayerInput playerInput;

    public bool isPaused = false;

    public GameObject pauseMenuUI;

    public TextHelper 
        time,
        points;

    private void Awake()
    {
        inventoryManager = GetComponentInChildren<InventoryManager>();
    }

    public void TogglePauseMenu()
    {
        if(inventoryManager.isOpen)
        {
            return;
        }

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
        //SceneManager.LoadScene("StartScene");
        LevelManager.Instance.LoadScene("StartScene", "CircleWipe");
    }

    public void ResetScene()
    {
        DataPersistenceManager.Instance.NewGame();

        //SceneManager.LoadScene("Level1");
        LevelManager.Instance.LoadScene("Level1", "CircleWipe");
    }

}
