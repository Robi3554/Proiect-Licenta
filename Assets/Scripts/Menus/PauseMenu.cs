using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InventoryManager inventoryManager;

    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private float currentTimeScale;

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
            currentTimeScale = Time.timeScale;
            Pause();
        }
    }

    public void Resume()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
        pauseMenuUI.SetActive(false);
        Time.timeScale = currentTimeScale;
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

        LevelManager.Instance.LoadScene("StartScene", "CircleWipe");
    }

    public void ResetScene()
    {
        DataPersistenceManager.Instance.NewGame();

        LevelManager.Instance.LoadScene("Level1", "CircleWipe");
    }

}
