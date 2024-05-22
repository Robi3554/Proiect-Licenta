using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField]
    private Button 
        newGame,
        continueGame,
        loadGame,
        options,
        quit;

    [SerializeField]
    private SaveSlotsMenu saveSlotsMenu;

    private void Start()
    {
        DisableButtonsDependingOnData();
    }

    private void DisableButtonsDependingOnData()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueGame.interactable = false;
            loadGame.interactable = false;
        }
    }

    public void NewGame()
    {
        saveSlotsMenu.ActivateMenu(false);
        DeactivateMenu();
    }

    public void LoadGame()
    {
        saveSlotsMenu.ActivateMenu(true);
        DeactivateMenu();
    }

    public void Continue()
    {
        DisableButtons();

        DataPersistenceManager.Instance.SaveGame();

        SceneManager.LoadSceneAsync("Level1");
    }

    private void DisableButtons()
    {
        newGame.interactable = false;
        continueGame.interactable = false;
        loadGame.interactable = false;
        options.interactable = false;
        quit.interactable = false;
    }

    public void ActivateMenu()
    {
        gameObject.SetActive(true);
        DisableButtonsDependingOnData();
    }

    public void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }

    public void QuitToDesktop()
    {
        DisableButtons();
        Application.Quit();
    }
}
